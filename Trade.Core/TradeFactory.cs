using System;
using System.Configuration;
using Trade.Core.Configuration;

namespace Trade.Core
{
    public class TradeFactory : ITradeFactory
    {
        public IDataProvider GetDataProvider()
        {
            string provider = ConfigurationManager.AppSettings["dataProvider"];

            IDataProvider dataProvider = Activator.CreateInstance(GetType(provider)) as IDataProvider;

            return dataProvider;
        }

        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;
        }
        public ModuleEvents GetModuleEvents()
        {
            var config = ConfigurationManager.GetSection("sexyExtensibility") as TradeModulesConfigurationSection;

            var moduleElementCollection = config.Modules;

            var moduleEvents = new ModuleEvents();

            foreach (ModuleElement moduleElement in moduleElementCollection)
            {
                string name = moduleElement.Name;
                string moduleType = moduleElement.Type;

                ITradeModule module = Activator.CreateInstance(Type.GetType(moduleType)) as ITradeModule;

                module.Initialize(moduleEvents);
            }

            return moduleEvents;

        }
    }
}
