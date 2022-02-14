using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Domain
{

    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }

}
