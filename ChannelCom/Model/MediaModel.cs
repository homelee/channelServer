using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChannelCom.Model
{
    [Serializable]
    [DataContract]
    public class MediaModel
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember] 
        public string ChannelId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }

        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public string Comments { get; set; }

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
        public int Height { get; set; }

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
        public long Size { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public long Duration { get; set; }
    }
}

