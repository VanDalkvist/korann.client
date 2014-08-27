using System.Configuration;

using MongoDB.Driver;

namespace Korann.DAL.Configuration
{
    public class DBConfig
    {
        private const string ContainerSectionKey = "korann/providers";

        private static readonly AppSettingsReader SettingsReader = new AppSettingsReader();

        private static IMongoSettings MongoSettings
        {
            get { return GetInstance().MongoSettings; }
        }

        private static MongoConfigurationSection GetInstance()
        {
            return (MongoConfigurationSection)ConfigurationManager.GetSection(ContainerSectionKey);
        }

        public static MongoUrl MongoUrl
        {
            get
            {
                var connectionSettings = ConfigurationManager.ConnectionStrings[MongoSettings.ConnectionStringName];
                return MongoUrl.Create(connectionSettings.ConnectionString);
            }
        }

        public TValue Get<TValue>(string key)
        {
            return (TValue)SettingsReader.GetValue(key, typeof (TValue));
        }
    }
}