using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Domain;

namespace RapidPay.Infra.Map
{
    public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .ToTable(typeof(TEntity).Name)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedNever();

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreateDate")
                .HasColumnType("varchar(50)")
                .ValueGeneratedNever();
        }
    }
}
