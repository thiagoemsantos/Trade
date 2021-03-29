using System;
using Trade.Core.Interfaces;

namespace Trade.Core.Categories
{
    public class DefaultedCategory : ITradeCategory
    {
        public bool IsTrue(ITrade trade)
        {
            return (trade.NextPaymentDate - DateTime.Now).TotalDays < 30;
        }
    }
}
