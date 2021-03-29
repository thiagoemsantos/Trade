using System.ComponentModel;
using Trade.Core.Interfaces;

namespace Trade.Core.EventArgs
{
    public class ProcessingDataEventArgs : CancelEventArgs
    {
        public ProcessingDataEventArgs(IPortfolio portfolio)
        {
            Portfolio = portfolio;
        }

        public IPortfolio Portfolio { get; set; }
    }
}