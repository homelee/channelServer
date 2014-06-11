using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChannelCom.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace ChannelCom.DAL
{
    public class ChannelDal
    {
        private static readonly MongoCollection Collection = Mongodb.MongoBase.GetCollection(EnumMongodbCollection.Channel);

        public static List<ChannelModel> List()
        {
            var list = Collection.AsQueryable<ChannelModel>().Where(n => n.Status != EnumChannelStatus.Delete && n.Status != EnumChannelStatus.Hidden).ToList();
            return list;
        }

        public static ChannelModel Get(string key, EnumChannelQueryKey type)
        {
            var query = Collection.AsQueryable<ChannelModel>();
            ChannelModel channel;

            switch (type)
            {
                case EnumChannelQueryKey.Id:
                    channel = query.FirstOrDefault(n => n.Id == ObjectId.Parse(key));
                    break;
                case EnumChannelQueryKey.LinkName:
                    channel = query.FirstOrDefault(n => n.LinkName == key);
                    break;
                case EnumChannelQueryKey.ParentId:
                    channel = query.FirstOrDefault(n => n.ParentId == key);
                    break;
                case EnumChannelQueryKey.Name:
                    channel = query.FirstOrDefault(n => n.Name == key);
                    break;
                default:
                    channel = null;
                    break;
            }

            return channel;
        }

        public static void DeleteChannel(string channelId)
        {
            var query = Query.EQ("_id", ObjectId.Parse(channelId));
            Collection.Remove(query);
        }

        public static void AddChannel(ChannelModel channel)
        {
            Collection.Insert(channel.ToBsonDocument());
        }

        public static void UpdateChannel(ChannelModel channel)
        {
            //var query = Query.EQ("_id", channel.Id);
            //var update = Update<ChannelModel>.Set(e => e.Description, channel.Description);

            //update.Set(u => u.Name, channel.Name);
            //update.Set(u => u.CateId, channel.CateId);
            //update.Set(u => u.Status, channel.Status);
            //update.Set(u => u.Image, channel.Image);
            //update.Set(u => u.CreateTime, channel.CreateTime);
            //update.Set(u => u.UpdateTime, DateTime.Now);

            //Collection.Update(query, update);
        }

        //public void UpdateChannel(ChannelModel channel, string channelId)
        //{
        //    var query = Query.EQ("_id", channelId);
        //    UpdateBuilder<ChannelModel> update = Update<ChannelModel>.Set(e => e.UpdateTime, DateTime.Now);

        //    var fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        //    for (int i = 0; i < fields.Length; i++)
        //    {
        //        var dd = fields[i].GetValue(this);
        //        if (!string.IsNullOrEmpty(channel.CateId))
        //        {


        //            var pa = Expression.Parameter(typeof(int), "i");
        //            //本地变量
        //            var loc = Expression.Variable(typeof(string), "str");
        //            //创建LabelTarget用来返回值
        //            LabelTarget labelTarget = Expression.Label(typeof(string));

        //            //调用i.ToString()
        //            MethodCallExpression med = Expression.Call(pa, typeof(object).GetMethod("ToString", new Type[] { }));
        //            //将结果赋值给本地字符串变量
        //            BinaryExpression asn = Expression.Assign(loc, med);
        //            //创建返回表达式（实际上就是Goto表达式）
        //            GotoExpression ret = Expression.Return(labelTarget, loc);
        //            //创建返回表达式的目标Label
        //            LabelExpression lbl = Expression.Label(labelTarget, Expression.Constant(String.Empty));
        //            //生成BlockExpression
        //            BlockExpression blocks = Expression.Block(
        //                new ParameterExpression[] { loc },
        //                asn,
        //                ret,
        //                lbl);
        //            //生成Lambda表达式
        //            Expression<Func<int, string>> lam = Expression.Lambda<Func<int, string>>(blocks,
        //                new ParameterExpression[] { pa });
        //            //运行并输出结果
        //            Func<int, string> del = lam.Compile();
        //            Console.WriteLine(del(17));

        //            Expression<Func<ChannelModel, string>> expression = u => u.Description;
        //            update.Set(u => u.CateId, channelId);
        //        }
        //    }


        //    if (!string.IsNullOrEmpty(channel.CateId)) update.Set(u => u.CateId, channelId);
        //    if (!string.IsNullOrEmpty(channel.Description)) update.Set(u => u.Description, channel.Description);
        //    if (!string.IsNullOrEmpty(channel.Image)) update.Set(u => u.Image, channel.Image);



        //    update.Set(u => u.UpdateTime, DateTime.Now);
        //    Collection.Update(query, update);
        //}

    }
}
