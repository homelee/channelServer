using System.Configuration;
using MongoDB.Driver;

namespace ChannelCom.Mongodb
{
    public class MongoBase
    {
        private static readonly string MongoDbConn = ConfigurationManager.AppSettings["mongodbcon"];


        static MongoDatabase Getdatabase()
        {
            var mongoUrl = new MongoUrl(MongoDbConn);
            var mongoClient = new MongoClient(mongoUrl);


            return mongoClient.GetServer().GetDatabase(mongoUrl.DatabaseName);

        }


        public static MongoCollection GetCollection()
        {
            var database = Getdatabase();
            return database.GetCollection<ChannelModel>("MediaInfo");
        }







    }
}
