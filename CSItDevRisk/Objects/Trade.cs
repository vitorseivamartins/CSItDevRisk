using CSItDevRisk.Enums;
using CSItDevRisk.Interfaces;
using System;

namespace CSItDevRisk.Objects
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        //public bool IsPoliticallyExposed { get; set; }

        public TradeCategory GetCategory(DateTime ReferenceDate)
        {
            if ((ReferenceDate - NextPaymentDate).Days > 30)
                return TradeCategory.DEFAULTED;
            else if (ClientSector.Equals("Private") && Value > 1000000)
                return TradeCategory.HIGHRISK;
            else if (ClientSector.Equals("Public") && Value > 1000000)
                return TradeCategory.MEDIUMRISK;
            //else if (IsPoliticallyExposed)
            //    return TradeCategory.PEP;
            else
                return TradeCategory.UNDEFINED;
        }
    }
}
