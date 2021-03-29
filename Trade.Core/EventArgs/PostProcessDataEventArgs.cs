using System.ComponentModel;
using Trade.Core.Interfaces;

namespace Trade.Core.EventArgs
{
    public class PostProcessDataEventArgs : CancelEventArgs
    {
        public PostProcessDataEventArgs(IPortfolio portfolio)
        {
            Portfolio = portfolio;
        }
        public IPortfolio Portfolio { get; set; }
    }
}