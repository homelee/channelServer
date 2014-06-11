using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChannelAPI.Controllers
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
