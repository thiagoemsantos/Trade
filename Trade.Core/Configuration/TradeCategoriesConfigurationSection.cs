using System.Configuration;

namespace Trade.Core.Configuration
{
    public class TradeCategoriesConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("categories", IsRequired = true)]
        public CategoryElementCollection Categories
        {
            get { return (CategoryElementCollection)base["categories"]; }
            set { base["categories"] = value; }
        }
    }
}
