using Trade.Core.EventArgs;

namespace Trade.Core
{
    public delegate void TradeModuleDelegate<T>(T e);
    public class ModuleEvents
    {
        public TradeModuleDelegate<CheckDataSourceEventArgs> CheckDataSource { get; set; }
        public TradeModuleDelegate<PreProcessDataEventArgs> PreProcessData { get; set; }
        public TradeModuleDelegate<ProcessingDataEventArgs> ProcessingData { get; set; }
        public TradeModuleDelegate<PostProcessDataEventArgs> PostProcessData { get; set; }
    }
}
