using Trade.Notification.Interfaces;

namespace Trade.Core
{
    public interface ITradeFactory
    {
        IDataProvider GetDataProvider(INotifier notifier);
        ModuleEvents GetModuleEvents();
    }
}
