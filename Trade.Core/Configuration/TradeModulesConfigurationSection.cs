using System.Configuration;

namespace Trade.Core.Configuration
{
    public class TradeModulesConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("modules", IsRequired = true)]
        public ModuleElementCollection Modules
        {
            get { return (ModuleElementCollection)base["modules"]; }
            set { base["modules"] = value; }
        }
    }
}
