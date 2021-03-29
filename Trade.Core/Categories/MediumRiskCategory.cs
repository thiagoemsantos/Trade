using Trade.Core.Interfaces;

namespace Trade.Core.Categories
{
    public class MediumRiskCategory : ITradeCategory
    {
        public bool IsTrue(ITrade trade)
        {
            if (trade.Value > 1000000.00 && trade.ClientSector.ToUpper() == "PUBLIC")
            {
                return true;
            }
            return false;
        }
    }
}
