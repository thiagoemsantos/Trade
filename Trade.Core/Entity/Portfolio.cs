using System;
using System.Collections.Generic;
using Trade.Core.Interfaces;

namespace Trade.Core.Entity
{
    public class Portfolio : IPortfolio
    {
        public Portfolio(DateTime referenceDate, int n, IList<ITrade> trades)
        {
            ReferenceDate = referenceDate;
            N = n;
            Trades = trades;
        }

        public DateTime ReferenceDate { get; }
        public int N { get; }
        public IList<ITrade> Trades { get; }
    }
}
