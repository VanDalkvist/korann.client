using System.Configuration;

namespace Korann.DAL.Configuration
{
    internal class MongoConfigurationElement : ConfigurationElement, IMongoSettings
    {
        private const string ConnectionStringKey = "connectionString";

        [ConfigurationProperty(ConnectionStringKey, IsRequired = true)]
        public string ConnectionStringName
        {
            get
            {
                return (string)this[ConnectionStringKey];
            }
            set
            {
                this[ConnectionStringKey] = value;
            }
        }
    }
}