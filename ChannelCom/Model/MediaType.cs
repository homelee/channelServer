using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace ChannelCom.Model
{

    [Serializable]
    [DataContract]
    public class MediaType
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string TypeName { get; set; }

    }
}
