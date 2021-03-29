using System.ComponentModel;
using Trade.Core.Interfaces;

namespace Trade.Core.EventArgs
{
    public class PreProcessDataEventArgs : CancelEventArgs
    {
        public PreProcessDataEventArgs(IPortfolio portfolio)
        {
            Portfolio = portfolio;
        }

        public IPortfolio Portfolio { get; set; }
    }
}