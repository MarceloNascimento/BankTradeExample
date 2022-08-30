namespace SampleBank.Challenge.BankTrades.Domain.Interfaces.Entities
{
    using System;
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
        bool IsPoliticallyExposed { get; }
    }
}