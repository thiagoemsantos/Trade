using Trade.Core.Interfaces;

namespace Trade.Core
{
    public interface IDataProvider
    {
        string GetSource();
        IPortfolio GetAndValidatePotfolio(string source);
        void LogData(string data);
    }
}
