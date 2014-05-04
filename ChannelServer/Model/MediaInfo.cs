using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Generator;

namespace ChannelServer.Model
{
    public class MediaInfo
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string SpecialTitle { get; set; }

        public string Img { get; set; }

        public List<KeyValueClass> MediaUrls { get; set; }

        public List<KeyValueClass> MediaTransUrls { get; set; }

        public string ArticleUrl { get; set; }

        public List<string> Author { get; set; }

        public int DownLoadCount { get; set; }

        public List<string> Tags { get; set; }

        public int Visible { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

    }

    public class KeyValueClass
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}