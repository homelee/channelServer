using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChannelCom;
using ChannelCom.Model;
using ChannelCom.Mongodb;
using MongoDB.Driver.Linq;

namespace ChannelServer.Controllers
{
    public class MediaController : ApiBaseController
    {
        [HttpGet]
        //[ApiAuthorizeAttribute(AllowAnonymous = true)]
        public HttpResponseMessage List(int page, int page_item, Guid id)
        {

            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        [HttpGet]
        public HttpResponseMessage Home()
        {
            var collection = MongoBase.GetCollection(EnumMongodbCollection.Cate);

            var dictword = collection.AsQueryable<MediaModel>().Take(50).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, dictword);
        } 

        // public string Get(int id)
        //{
        //    return "value";
        //}

        // public void Post([FromBody]string value)
        //{
        //}

        // public void Put(int id, [FromBody]string value)
        //{
        //}

        // public void Delete(int id)
        //{
        //}
    }
}