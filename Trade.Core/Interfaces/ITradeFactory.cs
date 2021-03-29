namespace Trade.Core
{
    public interface ITradeFactory
    {
        IDataProvider GetDataProvider();
        ModuleEvents GetModuleEvents();
    }
}
