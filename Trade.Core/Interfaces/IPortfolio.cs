using System;
using System.Collections.Generic;

namespace Trade.Core.Interfaces
{
    public interface IPortfolio
    {
        /// <summary>
        /// The first line of the input is the reference date.
        /// </summary>
        DateTime ReferenceDate { get; }
        /// <summary>
        /// The second line contains an integer n, the number of trades in the portfolio.
        /// </summary>
        int N { get; }
        /// <summary>
        /// The next n lines contain 3 elements each (separated by a space). First a double that  represents trade amount, 
        /// second a string that represents the client’s sector and third a date that represents the next pending payment.
        /// </summary>
        IList<ITrade> Trades { get; }
    }
}