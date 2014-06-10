using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelCom.Model
{
    public enum EnumChannelStatus
    {
        /// <summary>
        /// 删除
        /// </summary>
        Delete = -2,


        /// <summary>
        /// 隐藏
        /// </summary>
        Hidden = -1,

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 正常 状态
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 推荐
        /// </summary>
        Recommend = 2,
    }


    public enum EnumChannelParent
    {
        Default = 0,
        Shows = 1,
        Series = 2,
        Events = 3,
    }



    public enum EnumChannelQueryKey
    {

        Id,

   
        ParentId,

        Name,

        LinkName,

    }
}
