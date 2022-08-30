
using SampleBank.Challenge.BankTrades.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleBank.Challenge.BankTrades.Infra.Data.Mappings
{
    public class TradeMap : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("Trade");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.Block)
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Created)
                .HasColumnType("DATETIME");

            builder.Property(x => x.LastUpdated)
                .HasColumnType("DATETIME");

        }
    }
}
