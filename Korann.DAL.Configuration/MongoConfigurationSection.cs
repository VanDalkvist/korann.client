using System.Configuration;

namespace Korann.DAL.Configuration
{
    internal class MongoConfigurationSection : ConfigurationSection
    {
        private const string SettingsKey = "mongoSettings";

        [ConfigurationProperty(SettingsKey, IsRequired = true)]
        public MongoConfigurationElement MongoSettings
        {
            get
            {
                return (MongoConfigurationElement)base[SettingsKey];
            }
        }
    }
}