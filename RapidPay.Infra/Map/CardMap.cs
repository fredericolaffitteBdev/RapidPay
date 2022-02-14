using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Domain.Card;

namespace RapidPay.Infra.Map
{
    public class CardMap : EntityMap<CardData>
    {
        public override void Configure(EntityTypeBuilder<CardData> builder)
        {
            builder
                .Property(x => x.CardNumber)
                .HasColumnType("varchar(15)")
                .IsRequired();
            builder
                .Property(x => x.CVV)
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.ExpirationDate)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder
                .Property(x => x.IsCredit)
                .HasColumnType("bit")
                .IsRequired();
            builder
                .Property(x => x.Balance)
                .HasColumnType("decimal")
                .IsRequired();
            builder
                .Property(x => x.BalanceUsed)
                .HasColumnType("decimal")
                .IsRequired();
        }
    }
}
