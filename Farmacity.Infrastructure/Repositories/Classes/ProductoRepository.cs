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

    public override async Task<Producto> GetById(int id)
    {
            var recordDb = await _dbSet.Include(cb => cb.CodigosBarras).FirstOrDefaultAsync(x => x.Id == id);
            if (recordDb is null) return null!;
            return recordDb;
    }
}
