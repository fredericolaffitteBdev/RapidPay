using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Domain.Payment;

namespace RapidPay.Infra.Map
{
    public class PaymentMap : EntityMap<PaymentData>
    {
        public override void Configure(EntityTypeBuilder<PaymentData> builder)
        {
            builder
                .Property(x => x.PaymentDescription)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(x => x.PaymentValue)
                .HasColumnType("decimal")
                .IsRequired();

            builder
                .Property(x => x.PaymentDate)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.CardNumberPayment)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder
                .Property(x => x.PaymentResult)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder
                .Property(x => x.Receiver)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder
                .Property(x => x.FeeTransaction)
                .HasColumnType("Decimal")
                .IsRequired();

        }
    }
}
