using SampleBank.Challenge.BankTrades.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleBank.Challenge.BankTrades.Infra.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(180)")
                .IsRequired();

            builder.Property(x => x.BankNumber)
                .HasColumnType("NVARCHAR(10)");

            builder.Property(x => x.AgencyNumber)
                .HasColumnType("NVARCHAR(5)");

            builder.Property(x => x.AccountNumber)
                .HasColumnType("NVARCHAR(10)");    

            builder.Property(x => x.LastUpdated)
                .HasColumnType("DATETIME");
        }
    }
}
