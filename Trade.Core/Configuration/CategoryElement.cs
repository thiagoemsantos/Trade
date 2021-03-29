using System.Configuration;

namespace Trade.Core.Configuration
{
    public class CategoryElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true, DefaultValue = "")]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("priority", IsRequired = true, DefaultValue = 0)]
        public int Priority
        {
            get { return (int)base["priority"]; }
            set { base["priority"] = value; }
        }
    }
}
