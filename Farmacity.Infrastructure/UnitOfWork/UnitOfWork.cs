using Farmacity.Infrastructure.Data;
using Farmacity.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Farmacity.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public ICodigoBarraRepository CodigoBarraRepository { get; }
    public IProductoRepository ProductoRepository { get; }

    public UnitOfWork
        (
        ApplicationDbContext dbContext,
        ICodigoBarraRepository codigoBarraRepository,
        IProductoRepository productoRepository
        )
    {
        _dbContext = dbContext;
        CodigoBarraRepository = codigoBarraRepository;
        ProductoRepository = productoRepository;
    }


    public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
    {
        return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task<int> Complete(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
