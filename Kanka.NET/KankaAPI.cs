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

            // TODO: we need to immediately test the token for authorization
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

        public async Task<ResponseShell<Profile>> GetProfile()
        {
            var request = new RestRequest("profile", Method.Get);
            return await _client.GetAsync<ResponseShell<Profile>>(request);
        }
    }
}