namespace SampleBank.Challenge.BankTrades.Domain.Enums
{
    public enum TradesCategoriesEnum
    {
        EXPIRED,  //Trades whose next payment date is late by more than 30 days base on a reference date which will be given
        HIGHRISK, // Trades with value greater than 1,000,000 and client from Private Sector
        MEDIUMRISK, // Trades with value greater than 1,000,000 and client from Public Sector
        PEP, // Trades contain a politically exposed person
    }
}
