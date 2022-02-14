using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Domain.User;

namespace RapidPay.Infra.Map
{
    public class UserMap : EntityMap<UserData>
    {
        public override void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder
                .Property(x => x.UserName)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder
                .Property(x => x.Password)
                .HasColumnType("varchar(50)")
                .IsRequired();

        }
    }
}
