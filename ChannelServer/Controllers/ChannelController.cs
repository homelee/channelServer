  
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChannelServer.Controllers
{
    public class ChannelController : ApiController
    { 
        [HttpGet]
        public HttpResponseMessage List(string id)
        {
            var list = ChannelCom.DAL.ChannelDal.List();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        } 
    }
}
