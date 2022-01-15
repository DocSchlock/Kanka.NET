using Humanizer;
using Kanka.NET.models;
using Kanka.NET.models.interfaces;
using RestSharp;

namespace Kanka.NET
{
    public class KankaAPI
    {
        private const string API_VERSION = "1.0";
        private const string API_BASE_PATH = $"https://kanka.io/api/{API_VERSION}/";
        private readonly RestClient _client;

        public Profile TokenProfile { get; set; }

        public KankaAPI(string tokenString)
        {
            // only supports Personal Access Tokens at this time

            // create the default headers for the object
            var headers = new Dictionary<string, string>
            {
                { KnownHeaders.Authorization, $"Bearer {tokenString}" },
                { KnownHeaders.ContentType, "application/json" },
            };

            var options = new RestClientOptions(API_BASE_PATH)
            {
                FailOnDeserializationError = true,
                ThrowOnAnyError = true,
                DisableCharset = true
            };

            // create the restclient with the default headers and path
            _client = new RestClient(options)
                .AddDefaultHeaders(headers);

            // we need to immediately test the token for authorization
            // this has to be run sync to test in the constructor
            // Kanka revokes all tokens once per year due to system upgrades

            var profileResponse = GetProfile().GetAwaiter().GetResult(); // this will throw on bad auth

            if (profileResponse != null)
            {
                // we got data
                TokenProfile = profileResponse.Data;
            }
            else
                throw new ArgumentException("Check the authorization status on your token.");
        }

        // to run any non-Profile, non-Campaign functions, a Campaign must be selected

        //TODO Kanka will generate links that are http instead of https -> make sure to rewrite these when followed to avoid token leaks

        private async Task<T> Execute<T>(RestRequest request) where T : new()
        {
            var response = await _client.ExecuteAsync<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var kankaException = new Exception(message, response.ErrorException);
                throw kankaException;
            }
            return response.Data;
        }

        /// <summary>
        /// Get the profile of the current user
        /// </summary>
        /// <returns> Task<ResponseShell<Profile>></Profile></returns>
        public async Task<KankaResponse<Profile>> GetProfile()
        {
            var request = new RestRequest("profile", Method.Get);
            return await _client.GetAsync<KankaResponse<Profile>>(request);
        }

        /// <summary>
        /// Get all the Campaigns for the current user
        /// </summary>
        /// <returns>Task<ResponseShell<List<Campaign>>></returns>
        public async Task<KankaResponse<List<Campaign>>> GetCampaigns()
        {
            var request = new RestRequest("campaigns", Method.Get);
            return await _client.GetAsync<KankaResponse<List<Campaign>>>(request);
        }

        /// <summary>
        /// Generic Get method for all endpoints that require a campaign id
        /// This method can only accept classes that implement ICampaignRequired
        /// See GetCampaigns and GetProfile for those objects
        /// </summary>
        /// <typeparam name="T">T must be a model class</typeparam>
        /// <param name="campaign_id">a valid campaign id - get this beforehand</param>
        /// <param name="endpointId">the id of the object you want to receive from the endpoint - do not use if you want all results from the endpoint</param>
        /// <returns>Task<ResponseShell<T>></returns>
        public async Task<KankaResponse<T>> GetEndpoint<T>(int campaign_id, int? endpointId = null) where T : ICampaignRequired, new()
        {
            string path = $"campaigns/{campaign_id}/{typeof(T).Name.Pluralize}";
            if (endpointId != null)
                path += $"/{endpointId}";

            var request = new RestRequest(path, Method.Get);

            return await _client.GetAsync<KankaResponse<T>>(request);
        }
    }
}