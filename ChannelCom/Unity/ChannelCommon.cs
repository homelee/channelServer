using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using ChannelCom.DAL;
using ChannelCom.Model;
using HtmlAgilityPack;
using UnityCommon;

namespace ChannelCom.Unity
{
    public class ChannelCommon
    {
        static Tuple<string, string, string, string> GetInfoByLink(string link)
        {
            //http://channel9.msdn.com/Blogs/DevRadio/标题
            //http://channel9.msdn.com/Shows/Cloud+Cover/标题
            //http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/标题
            //http://channel9.msdn.com/Series/Windows-Phone-8-1-D e-Beginners/标题 
            //http://channel9.msdn.com/Series/Windows-Azure-Web-Sites-Tutorials/ 标题
            //http://channel9.msdn.com/Events/TechDays/Techdays-2014-the-Netherlands/标题
            //http://channel9.msdn.com/Events/ALM-Summit/2010/标题

            link = link.Replace("http://", "").ToLower();

            var type = "";
            var cateLinkName = "";
            var channelLinkName = "";
            var title = "";


            if (link.Contains("channel9.msdn.com/Blogs/".ToLower()) || link.Contains("channel9.msdn.com/Series/".ToLower()) || link.Contains("channel9.msdn.com/Shows/".ToLower()))
            {
                var array = link.Split('/').ToList();
                type = array[1];
                channelLinkName = array[2];
                title = array[3];
                cateLinkName = "";
            }
            else if (link.Contains("channel9.msdn.com/Events/".ToLower()))
            {
                var array = link.Split('/').ToList();
                type = array[1];
                cateLinkName = array[2];
                channelLinkName = array[3];
                title = array[4];
            }
            else
            {
                Console.WriteLine("link");
                Thread.Sleep(33000);
            }

            var tups = new Tuple<string, string, string, string>(type, channelLinkName, title, cateLinkName);

            return tups;
        }

        /// <summary>
        /// 得到频道的地址.根据单个资源的地址拆分
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static string GetChannelLinkByMediaUrl(string link)
        {
            //http://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-93-TechEd-2014-Troubleshooting-Talks
            //http://channel9.msdn.com/Events/dotnetConf/2014/The-State-of-NET

            link = link.ToLower();
            return link.Substring(0, link.LastIndexOf('/'));
        }

        public static ChannelModel GetChannelIdByLink(string link)
        {
            var info = GetInfoByLink(link);

            if (info == new Tuple<string, string, string, string>("", "", "", "") || string.IsNullOrEmpty(info.Item2) || string.IsNullOrEmpty(info.Item3))
            {
                return null;
            }
            var type = info.Item1;
            var channelLinkName = info.Item2;
            var title = info.Item3;
            var cateLinkName = info.Item4;

            ChannelModel channel = ChannelDal.Get(GetChannelInfoByLink(link, false).link, EnumChannelQueryKey.LinkName);

            if (channel == null)
            {
                //insert new channelid

                if (info.Item1.ToLower() != "events")
                {
                    var channelInfo = GetChannelInfoByLink(link, false);
                    ChannelModel newchannel = new ChannelModel()
                    {
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        Name = channelInfo.title,// info.Item2,
                        Description = channelInfo.descrtiption,// info.Item2, 
                        Image = channelInfo.image,
                        LinkName = channelInfo.link,
                        ParentId = null,
                        ParentType = EnumChannelParent.Default,
                        Status = EnumChannelStatus.Normal
                    };

                    ChannelDal.AddChannel(newchannel);

                    channel = ChannelDal.Get(info.Item2, EnumChannelQueryKey.Name);
                }
                else
                {
                    var bigChannelInfo = GetChannelInfoByLink(link, true);
                    //新建大频道.再建小频道 
                    ChannelDal.AddChannel(new ChannelModel()
                    {
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        Name = bigChannelInfo.title,//info.Item2,
                        Description = bigChannelInfo.descrtiption,//info.Item2,
                        Image = bigChannelInfo.image,
                        LinkName = bigChannelInfo.link,
                        ParentId = null,
                        ParentType = EnumChannelParent.Events,
                        Status = EnumChannelStatus.Normal
                    });

                    var parentChanenl = ChannelDal.Get(bigChannelInfo.title, EnumChannelQueryKey.Name);
                    var channelInfo = GetChannelInfoByLink(link, false);
                    ChannelDal.AddChannel(new ChannelModel()
                    {
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        Name = channelInfo.title,// info.Item3,
                        Description = channelInfo.descrtiption,// info.Item3,
                        Image = channelInfo.image,
                        LinkName = channelInfo.link,
                        ParentId = parentChanenl.Id.ToString(),
                        ParentType = EnumChannelParent.Events,
                        Status = EnumChannelStatus.Normal
                    });

                    channel = ChannelDal.Get(info.Item3, EnumChannelQueryKey.Name);

                }
            }
            return channel;
        }

        /// <summary>
        /// http://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-93-TechEd-2014-Troubleshooting-Talks 
        /// 通过地址,得到这个频道的内容,信息,最后更新时间
        /// </summary>
        /// <returns></returns>
        public static dynamic GetChannelInfoByLink(string link, bool isBigCate)
        {
            link = GetChannelLinkByMediaUrl(link);
            if (isBigCate)
            {
                link = GetChannelLinkByMediaUrl(link);
            }

            dynamic channel = new System.Dynamic.ExpandoObject();

            var html = DownLoadCom.DownLoadHtml(link);
            if (string.IsNullOrEmpty(html))
            {
                return null;
            }

            var htmlDoc = new HtmlDocument();
            //doc.DocumentNode. 
            htmlDoc.LoadHtml(html);
            var headHtml = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='area-header item-header']");

            var imageHtml = "";
            try
            {
                imageHtml = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='mainHolder showBanner']").Attributes["style"]
                      .Value;
            }
            catch (Exception)
            {
                imageHtml = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='firstContent text']").InnerHtml;
            }

            //catch里面的是Event的内容.所


            var title = headHtml.SelectSingleNode("h1").InnerText;

            var description = "";
            try
            {
                description = headHtml.SelectSingleNode("p").InnerText;
            }
            catch (Exception)
            {
                description = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='description']").InnerText;
            }

            channel.link = link;
            channel.title = title;
            channel.descrtiption = description;
            channel.image = RegexCom.ImageUrl(imageHtml);
            return channel;
        }
    }
}
