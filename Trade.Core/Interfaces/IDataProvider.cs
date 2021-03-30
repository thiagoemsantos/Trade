using Trade.Core.Interfaces;
using Trade.Notification.Interfaces;

namespace Trade.Core
{
    public interface IDataProvider
    {
        string GetSource();
        IPortfolio GetAndValidatePotfolio(string source);
        void Initialize(INotifier notifier);
        void LogData(string data);
    }
}
