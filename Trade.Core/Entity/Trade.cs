using System;
using Trade.Core.Interfaces;

namespace Trade.Core.Entity
{
    public class Trade : ITrade
    {
        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }


        public double Value { get; }

        public string ClientSector { get; }

        public DateTime NextPaymentDate { get; }

        public string Category { get; private set; }

        public void SetCategory(string category)
        {
            this.Category = category;
        }
    }
}
