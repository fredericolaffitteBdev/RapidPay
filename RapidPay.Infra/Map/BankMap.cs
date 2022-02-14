using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Domain.BankAccount;

namespace RapidPay.Infra.Map
{
    public class BankMap : EntityMap<BankData>
    {
        public override void Configure(EntityTypeBuilder<BankData> builder)
        {
            builder
                .Property(x => x.BankAccountNumber)
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.BankName)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder
                .Property(x => x.BankAgencyNumber)
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.BankId)
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.BankAmount)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
