using Korann.DAL.Configuration;

using MongoDB.Driver;

namespace Korann.DAL.Management
{
    public class DBManager
    {
        private static MongoDatabase _database;

        public static MongoDatabase Database
        {
            get { return _database ?? (_database = ConnectToDatabase(DBConfig.MongoUrl)); }
        }

        private static MongoDatabase ConnectToDatabase(MongoUrl connectionUrl)
        {
            var client = new MongoClient(connectionUrl);
            var server = client.GetServer();
            return server.GetDatabase(connectionUrl.DatabaseName);
        }
    }
}