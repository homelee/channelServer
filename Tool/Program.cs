using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;
using MongoDB.Driver.Linq;

namespace Tool
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const string rssUrl = "http://channel9.msdn.com/Feeds/RSS";

            var content = new HttpClient().GetStringAsync(rssUrl).Result;
           

            var list = new List<ChannelModel>();






            XElement config = XElement.Parse(content);


            XElement newx = XElement.Parse(config.FirstNode.ToString());


            foreach (var item in newx.Descendants("item"))
            {  
                list.Add(new ChannelModel()
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    Link = item.Element("link").Value,
                    Guid = item.Element("guid").Value,


                    CreateTime = Convert.ToDateTime(item.Element("pubDate").Value), 
                });
            }

  
  <comments>http://channel9.msdn.com/Series/Windows-Phone-8-1-Development-for-Absolute-Beginners/Part-1-Series-Introduction</comments>
  <itunes:summary xmlns:itunes="http://www.itunes.com/dtds/podcast-1.0.dtd">Hello, and welcome to this series on Windows Phone 8.1 development for Absolute Beginners. My name is Bob Tabor, and for the past 12 years I've created screen cast tra nc  </itunes:summary>
  <itunes:duration xmlns:itunes="http://www.itunes.com/dtds/podcast-1.0.dtd">427</itunes:duration>
   <media:thumbnail url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1_100.jpg" height="56" width="100" xmlns:media="http://search.yahoo.com/mrss/"></media:thumbnail>
  <media:thumbnail url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1_220.jpg" height="123" width="220" xmlns:media="http://search.yahoo.com/mrss/"></media:thumbnail>
  <media:thumbnail url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1_512.jpg" height="288" width="512" xmlns:media="http://search.yahoo.com/mrss/"></media:thumbnail>
  <media:thumbnail url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1_960.jpg" height="540" width="960" xmlns:media="http://search.yahoo.com/mrss/"></media:thumbnail>
  <media:group xmlns:media="http://search.yahoo.com/mrss/">
    <media:content url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1.mp3" expression="full" duration="427" fileSize="6842148" type="audio/mp3" medium="audio"></media:content>
    <media:content url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1.mp4" expression="full" duration="427" fileSize="10887142" type="video/mp4" medium="video"></media:content>
    <media:content url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1.webm" expression="full" duration="427" fileSize="28404374" type="video/webm" medium="video"></media:content>
    <media:content url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1_high.mp4" expression="full" duration="427" fileSize="38460870" type="video/mp4" medium="video"></media:content>
    <media:content url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1_mid.mp4" expression="full" duration="427" fileSize="28011278" type="video/mp4" medium="video"></media:content>
  </media:group>
  <enclosure url="http://media.ch9.ms/ch9/89c3/5fb218e7-7239-44f4-a566-fb436b5d89c3/ABSWP81Part1.mp4" length="10887142" type="video/mp4"></enclosure>
  <dc:creator xmlns:dc="http://purl.org/dc/elements/1.1/">BobTabor, Matthias Shapiro, Larry Lieberman</dc:creator>
  <itunes:author xmlns:itunes="http://www.itunes.com/dtds/podcast-1.0.dtd">BobTabor, Matthias Shapiro, Larry Lieberman</itunes:author>
  <slash:comments xmlns:slash="http://purl.org/rss/1.0/modules/slash/">4</slash:comments>
  <wfw:commentRss xmlns:wfw="http://wellformedweb.org/CommentAPI/">http://channel9.msdn.com/Series/Windows-Phone-8-1-Development-for-Absolute-Beginners/Part-1-Series-Introduction/RSS</wfw:commentRss>
  <category>C#</category>
  <category>XAML</category>
</item>

            var collection = Mongodb.MongoBase.GetCollection();
            var dictword =     collection.AsQueryable<ChannelModel>().OrderBy(n => n.Id);
 
        }
    }
}


