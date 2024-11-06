using Farmacity.Domain.Models;
using Farmacity.Infrastructure.Data;
using Farmacity.Infrastructure.Repositories.Interfaces;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Farmacity.Infrastructure.Repositories.Classes;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }

    public override async Task<List<Producto>> GetAllWithPagination(PaginationDto paginationDto)
    {
        var recordsQueriable = _dbSet.AsQueryable();

        return await recordsQueriable.Paginate(paginationDto).Include(x => x.CodigosBarras).ToListAsync();
    }

    public async Task<List<Producto>> GetProductsByStatus(PaginationDto paginationDto, bool? isActive = null)
    {
        var recordsQueriable = _dbSet
            .Include(x => x.CodigosBarras)
            .IgnoreQueryFilters()
            .AsQueryable();

        if (isActive.HasValue)
        {
            recordsQueriable = recordsQueriable.Where(p => p.Activo == isActive.Value);
        }

        return await recordsQueriable
            .Paginate(paginationDto)
            .ToListAsync();
    }


    public override async Task<Producto> GetById(int id)
    {
            var recordDb = await _dbSet.Include(cb => cb.CodigosBarras).FirstOrDefaultAsync(x => x.Id == id);
            if (recordDb is null) return null!;
            return recordDb;
    }

    public async Task<Producto> GetByIdWithoutFilters(int id)
    {
        Producto? product = await _dbSet
            .IgnoreQueryFilters()
            .Include(p => p.CodigosBarras)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) return null!;

        return product;
    }
}
