using Trade.Core.Interfaces;

namespace Trade.Core.Categories
{
    public class HighRiskCategory : ITradeCategory
    {
        public bool IsTrue(ITrade trade)
        {
            if (trade.Value > 1000000.00 && trade.ClientSector.ToUpper() == "PRIVATE")
            { 
                return true;
            }
            return false;
        }
    }
}
