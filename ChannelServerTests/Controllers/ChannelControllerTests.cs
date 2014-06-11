using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChannelServer.Controllers;
using Xunit;
namespace ChannelServer.Controllers.Tests
{
    public class ChannelControllerTests
    {
        private static readonly string _url = "";

        [Fact()]
        public void ListTest()
        {
            string url = _url + "api/v3/media/MediaSentence/1174d10b-6e0b-479a-b680-57388a656e27";
            using (var httpClient = new HttpClient())
            {
                var message = new HttpRequestMessage(HttpMethod.Get, url);

                var response = httpClient.SendAsync(message).Result; 
                var content = response.Content.ReadAsStringAsync().Result;

                Assert.NotNull(content);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            } 
        }
    }
}
