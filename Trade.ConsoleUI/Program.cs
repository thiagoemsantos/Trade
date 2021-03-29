using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using Trade.Core;
using Trade.Core.Configuration;
using Trade.Core.EventArgs;
using Trade.IoC;

namespace Trade.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            NativeInjectorBootStrapper.ResolveDependencies(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var tradeFactory = serviceProvider.GetService<ITradeFactory>();
            CategorizePortfolio(tradeFactory);
            Console.ReadLine();
        }


        private static void CategorizePortfolio(ITradeFactory tradeFactory)
        {
            Output("--- Starting Process ---");

            // get modules
            var config = ConfigurationManager.GetSection("tradeModules") as TradeModulesConfigurationSection;

            var moduleElementCollection = config.Modules;

            var moduleEvents = new ModuleEvents();

            foreach (ModuleElement moduleElement in moduleElementCollection)
            {
                //string name = moduleElement.Name;
                string moduleType = moduleElement.Type;
                var type = Type.GetType(moduleType);
                ITradeModule module = Activator.CreateInstance(type) as ITradeModule;
                module.Initialize(moduleEvents);
                
                Output("Loaded and initialized module '" + moduleType + "'.");
            }

            var provider = tradeFactory.GetDataProvider();

            var source = provider.GetSource();

            Output("GetSource returned:");
            Output(source);

            bool cancel = false;


            if (moduleEvents.CheckDataSource != null)
            {
                var eventArgs = new CheckDataSourceEventArgs(source);

                moduleEvents.CheckDataSource.Invoke(eventArgs);

                cancel = eventArgs.Cancel;

                Output("Processed 'CheckDataSource' operations - Cancel is set to " + cancel.ToString() + ".");
            }

            //-------------------------------------------------------

            if (!cancel)
            {
                var portfolio = provider.GetAndValidatePotfolio(source);

                Output("Portfolio obtained.");

                if (moduleEvents.PreProcessData != null)
                {
                    PreProcessDataEventArgs eventArgs = new PreProcessDataEventArgs(portfolio);

                    moduleEvents.PreProcessData.Invoke(eventArgs);

                    portfolio = eventArgs.Portfolio;

                    Output("Processed 'PreProcessData' operations.");

                }

                if (moduleEvents.ProcessingData != null)
                {
                    var eventArgs = new ProcessingDataEventArgs(portfolio);

                    moduleEvents.ProcessingData.Invoke(eventArgs);
                   
                    foreach( var trade in portfolio.Trades)
                    {
                        Output(trade.Category, true);
                    }

                    Output("Processed 'ProcessingData' operations.");
                }

                if (moduleEvents.PostProcessData != null)
                {
                    PostProcessDataEventArgs eventArgs =
                        new PostProcessDataEventArgs(portfolio);

                    moduleEvents.PostProcessData.Invoke(eventArgs);

                    Output("Processed 'PostProcessData' operations.");

                }

            }
        }

        private static void Output(string message, bool canShow = false)
        {
            if(canShow)
            Console.WriteLine(message);
        }

    }
}
