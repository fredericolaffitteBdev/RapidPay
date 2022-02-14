using Microsoft.EntityFrameworkCore;
using RapidPay.Domain;
using RapidPay.Domain.BankAccount;
using RapidPay.Domain.Card;
using RapidPay.Domain.Payment;
using RapidPay.Domain.User;
using RapidPay.Infra.Map;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Infra
{
    public class Context : DbContext, IUnitOfWork
    {
        public Context(DbContextOptions<Context> options)
      : base(options)
        {
        }


        public DbSet<UserData> Users { get; set; }
        public DbSet<CardData> Cards { get; set; }
        public DbSet<BankData> Banks { get; set; }
        public DbSet<PaymentData> Payments { get; set; }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankMap());
            modelBuilder.ApplyConfiguration(new CardMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
