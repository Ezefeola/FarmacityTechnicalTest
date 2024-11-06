using Farmacity.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Farmacity.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICodigoBarraRepository CodigoBarraRepository { get; }
    IProductoRepository ProductoRepository { get; }

    Task<int> Complete(CancellationToken cancellationToken);
    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}
