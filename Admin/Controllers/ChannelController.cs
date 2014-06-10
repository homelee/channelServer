using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChannelCom.DAL;
using ChannelCom.Model;
using MongoDB.Bson;

namespace Admin.Controllers
{
    public class ChannelController : BaseController
    {
        public ActionResult Index(string cateid)
        {
            //var list = ChannelCom.DAL.ChannelDal.GetList(cateid);
            //ViewBag.list = list;
            return View();
        }


        [HttpGet]
        public ActionResult Insert(string id = "")
        {
            var cate = new ChannelModel();
            if (!string.IsNullOrEmpty(id))
            {
                cate = ChannelDal.Get(id,EnumChannelQueryKey.Id);
            }
             
            ViewBag.cate = cate;
            return View();
        }


        [HttpPost]
        public ActionResult Insert(string id, ChannelModel channel)
        {
            channel.UpdateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(id))
            {
                channel.Id = ObjectId.Parse(id);
                ChannelDal.UpdateChannel(channel);
            }
            else
            {
                channel.CreateTime = DateTime.Now;
                channel.Status = EnumChannelStatus.Normal;
                ChannelDal.AddChannel(channel);
            }

            return RedirectToRoute(Insert());
        }



    }
}