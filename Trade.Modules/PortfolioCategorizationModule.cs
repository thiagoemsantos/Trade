using System;
using System.Configuration;
using System.Linq;
using Trade.Core;
using Trade.Core.Configuration;
using Trade.Core.EventArgs;
using Trade.Core.Interfaces;

namespace Portfolio
{
    public class PortfolioCategorizationModule : ITradeModule
    {
        public void Initialize(ModuleEvents events)
        {
            events.ProcessingData += events_ProcessingData;
        }

        private void events_ProcessingData(ProcessingDataEventArgs e)
        {
            foreach (var trade in e.Portfolio.Trades)
            {
                var category = ResolveCategory(trade);
                trade.SetCategory(category);
            }
        }

        private string ResolveCategory(ITrade trade)
        {
            var config = ConfigurationManager.GetSection("tradeCategories") as TradeCategoriesConfigurationSection;

            var collection = (CategoryElementCollection)config.Categories;
            var orderedList = collection.Cast<CategoryElement>().OrderBy(x => x.Priority).ToList();

            foreach (CategoryElement element in orderedList)
            {
                var name = element.Name;
                var type = element.Type;
                var priority = element.Priority;

                var category = Activator.CreateInstance(Type.GetType(type)) as ITradeCategory;
                if(category.IsTrue(trade))
                {
                    return name;
                }
            }

            return "UNCATEGORIZED";
        }
    }
}
