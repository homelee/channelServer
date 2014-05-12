using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Tool
{
    [Serializable]
    [DataContract]
    public class ChannelModel
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public List<ImageContent> Images { get; set; }
        [DataMember]
        public List<VideoContent> Videos { get; set; }

        [DataMember]
        public List<string> Authors { get; set; }
        [DataMember]
        public List<string> Categorys { get; set; }
    }
    
    [Serializable]
    [DataContract]
    public class ImageContent
    {
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Height { get; set; }
        [DataMember]
        public int Width { get; set; }
    }

    [Serializable]
    [DataContract]
    public class VideoContent
    {
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Duration { get; set; }
    }
}

