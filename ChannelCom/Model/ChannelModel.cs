using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChannelCom.Model
{

    [Serializable]
    [DataContract]
    public class ChannelModel
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }
         
     
        /// <summary>
        /// Shows  Series  Event
        /// </summary>
        [DataMember]
        public EnumChannelParent ParentType { get; set; }



        /// <summary>
        /// 当只有为Event的时候,才会有父类id
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LinkName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }

        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public EnumChannelStatus Status { get; set; }

    } 


    
}
