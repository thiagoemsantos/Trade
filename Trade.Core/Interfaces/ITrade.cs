using System;

namespace Trade.Core.Interfaces
{
    public interface ITrade
    { 
       /// <summary>
      /// indicates the transaction amount in dollars
      /// </summary>
        double Value { get; }
        
        /// <summary>
        ///indicates the client's sector which can be "Public" or "Private" 
        /// </summary>
        string ClientSector { get; }
        /// <summary>
        ///indicates the category. This information is processed by the categorizationModule. 
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Sets category
        /// </summary>
        /// <param name="category"></param>
        void SetCategory(string category);

        /// <summary>
        /// indicates when the next payment from the client to the bank is expected
        /// </summary>
        DateTime NextPaymentDate { get; }
    }
}
