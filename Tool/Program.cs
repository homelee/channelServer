using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;
using ChannelCom;
using ChannelCom.Model;
using ChannelCom.Mongodb;
using ChannelCom.Unity;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rssUrl = "http://channel9.msdn.com/Feeds/RSS";
            XNamespace media = "http://search.yahoo.com/mrss/";
            XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            XNamespace wfw = "http://wellformedweb.org/CommentAPI/";

            var content = new HttpClient().GetStringAsync(rssUrl).Result;

            var list = new List<MediaModel>();
            XElement config = XElement.Parse(content);
            XElement newx = XElement.Parse(config.FirstNode.ToString());

            foreach (var item in newx.Descendants("item"))
            {
                var category = item.Descendants("category").Select(u => u.Value);
                var videosElement = item.Descendants(media + "content");
                var imagesElement = item.Descendants(media + "thumbnail");

                var videos = videosElement.Select(el => new VideoContent()
                {
                    Duration = el.Attribute("duration") == null ? 0 : long.Parse(el.Attribute("duration").Value),
                    Url = el.Attribute("url").Value,
                    Size = el.Attribute("fileSize") == null ? 0 : long.Parse(el.Attribute("fileSize").Value),
                    Type = el.Attribute("type").Value,
                }).ToList();

                var images = imagesElement.Select(el => new ImageContent()
                {
                    Height = int.Parse(el.Attribute("height").Value),
                    Url = el.Attribute("url").Value,
                    Width = int.Parse(el.Attribute("width").Value)
                }).ToList();


                var link = item.Element("link").Value; 
                if (link.Contains("http://channel9.msdn.com/coding4fun"))
                {
                    continue;
                }

                var channel = ChannelCommon.GetChannelIdByLink(link);


                list.Add(new MediaModel
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    ChannelId = channel != null ? channel.Id.ToString() : null,
                    Link = link,
                    Guid = item.Element("guid").Value,
                    Comments = "",
                    Categorys = category.ToList(),
                    Videos = videos,
                    Images = images,
                    Authors = item.Descendants(itunes + "author").Select(u => u.Value).ToList()[0].Split(',').Select(u => u.Trim()).ToList(),
                    UpdateTime = DateTime.UtcNow,
                    CreateTime = Convert.ToDateTime(item.Element("pubDate").Value).ToUniversalTime(),
                });

            }

            var collection = MongoBase.GetCollection(EnumMongodbCollection.Medias);

            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
                var dictword = collection.AsQueryable<MediaModel>().Any(u => u.Guid == item.Guid);
                if (!dictword)
                {
                    collection.Insert(item.ToBsonDocument());
                }
            }

            Console.WriteLine("over");
            Thread.Sleep(5000);

        }
    }
}


