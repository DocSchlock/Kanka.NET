using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Text.Json;
using Kanka.NET.models;

namespace Kanka.NET.Tests
{
    [TestClass]
    public class SessionTests
    {
        private string _token = "", _response = "";
        private KankaAPI _client;

        [TestInitialize]
        public void Setup()
        {
            // get the testing key from the file
            _token = System.IO.File.ReadAllText(@".\config\testingkey.txt");
            _response = System.IO.File.ReadAllText(@".\config\exampleResponse.txt");
            _client = new(_token);
        }

        [TestMethod]
        public async Task TestGetProfile()
        {
            var prof = await _client.GetProfile();
            Assert.IsNotNull(prof);
            Assert.IsTrue(prof.Data?.Name?.Equals("DocSchlock"));
        }

        public async Task TestGetAllCampaigns()
        {
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var obj = JsonSerializer.Deserialize<ResponseShell<Profile>>(_response);

            Assert.IsNotNull(obj);
        }
    }
}