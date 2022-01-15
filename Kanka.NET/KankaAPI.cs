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
        /// <param name="campaignId">a valid campaign id - get this beforehand</param>
        /// <param name="endpointId">the id of the object you want to receive from the endpoint - do not use if you want all results from the endpoint</param>
        /// <returns>Task<ResponseShell<T>></returns>
        public async Task<KankaResponse<T>> GetEndpoint<T>(int campaignId, int? endpointId = null) where T : ICampaignRequired, new()
        {
            string path = GetEndpointPath<T>(campaignId, endpointId);

            var request = new RestRequest(path, Method.Get);

            return await _client.GetAsync<KankaResponse<T>>(request);
        }

        public async Task<KankaResponse<X>> GetSubEndpoint<T, X>(int campaignId, int endpointId, int? subEndpointId = null) where T : ICampaignRequired, new() where X : ISubEndpoint, new()
        {
            string path = GetSubEndpointPath<T, X>(campaignId, endpointId, subEndpointId);

            var request = new RestRequest(path, Method.Get);

            return await _client.GetAsync<KankaResponse<X>>(request);
        }

        /// <summary>
        /// deletes a specific record from a main endpoint
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="campaignId"></param>
        /// <param name="endpointId"></param>
        /// <returns></returns>
        public async Task<KankaResponse<T>> DeleteEndpointId<T>(int campaignId, int endpointId) where T : ICampaignRequired, new()
        {
            string path = GetEndpointPath<T>(campaignId, endpointId);

            var request = new RestRequest(path, Method.Delete);

            return await _client.DeleteAsync<KankaResponse<T>>(request);
        }

        /// <summary>
        /// deletes a specifc record from a sub-endpoint
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="X"></typeparam>
        /// <param name="campaignId"></param>
        /// <param name="endpointId"></param>
        /// <param name="subEndpointId"></param>
        /// <returns></returns>
        public async Task<KankaResponse<X>> DeleteSubEndpointId<T, X>(int campaignId, int endpointId, int subEndpointId) where T : ICampaignRequired, new() where X : ISubEndpoint, new()
        {
            string path = GetSubEndpointPath<T, X>(campaignId, endpointId, subEndpointId);

            var request = new RestRequest(path, Method.Get);

            return await _client.DeleteAsync<KankaResponse<X>>(request);
        }

        /// <summary>
        /// Gets the path to the endpoint
        /// Can be used to get a specific record as well
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="campaign_id"></param>
        /// <param name="endpointId"></param>
        /// <returns></returns>
        private string GetEndpointPath<T>(int campaign_id, int? endpointId = null) where T : ICampaignRequired, new()
        {
            string path = $"campaigns/{campaign_id}/{typeof(T).Name.Pluralize}";
            if (endpointId != null)
                path += $"/{endpointId}";

            return path;
        }

        /// <summary>
        /// Returns the value of a sub-endpoint
        /// </summary>
        /// <typeparam name="T">main endpoint below campaign</typeparam>
        /// <typeparam name="X">sub-endpoint of main endpoint</typeparam>
        /// <param name="campaign_id"></param>
        /// <param name="endpointId"></param>
        /// <returns></returns>
        private static string GetSubEndpointPath<T, X>(int campaign_id, int endpointId, int? subEndpointId) where T : ICampaignRequired, new() where X : ISubEndpoint, new()
        {
            // TODO need to add underscores to sub point
            // use reflection to invoke a static method on the sub endpoints to get the path
            // if returns null then use the regular pluralize
            var path = $"campaigns/{campaign_id}/{typeof(T).Name.Pluralize}/{endpointId}/";
            try
            {
                // get the subendpoint path
                // this code is to make sure the underscore paths are correct
                var obj = typeof(X).GetMethod("GetPath")?.Invoke(null, null);
                if (obj == null || obj.ToString() == string.Empty)
                    path += $"{typeof(X).Name.Pluralize}";
                else
                    path += $"{obj}";

                // add the subendpointid if not null
                if (subEndpointId != null)
                    path += $"/{subEndpointId}";
            }
            catch (Exception ex)
            {
                path = string.Empty;
            }

            return path;
        }
    }
}