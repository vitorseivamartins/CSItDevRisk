namespace CSItDevRisk.Enums
{
    public enum TradeCategory
    {
        DEFAULTED,  //Trades whose next payment date is late by more than 30 days based on a reference date which will be given.
        HIGHRISK,   //Trades with value greater than 1,000,000 and client from Private Sector.
        MEDIUMRISK, //Trades with value greater than 1,000,000 and client from Public Sector.
        //PEP,        //politically exposed person
        UNDEFINED
    }
}
