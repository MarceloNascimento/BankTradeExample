namespace SampleBank.Challenge.BankTrades.Infrastructure.CrossCutting.Interfaces.Entities
{
    using System;
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }
}