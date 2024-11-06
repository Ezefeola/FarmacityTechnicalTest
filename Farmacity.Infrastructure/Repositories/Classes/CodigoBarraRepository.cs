using Farmacity.Domain.Models;
using Farmacity.Infrastructure.Data;
using Farmacity.Infrastructure.Repositories.Interfaces;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Farmacity.Infrastructure.Repositories.Classes;

public class CodigoBarraRepository : GenericRepository<CodigoBarra>, ICodigoBarraRepository
{
    public CodigoBarraRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<List<CodigoBarra>> GetCodeBarsWithFilters(PaginationDto paginationDto, bool? isActive = null)
    {
        var recordsQueriable = _dbSet
            .Include(x => x.Producto)
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

    public async Task<List<CodigoBarra>> GetCodeBarsById(int id)
    {
        List<CodigoBarra> recordsDb = await _dbSet.Where(x => x.ProductoId == id).ToListAsync();
        return recordsDb!;
    }

    public async Task<CodigoBarra> GetByIdWithoutFilters(int id)
    {
        CodigoBarra? codeBar = await _dbSet
            .IgnoreQueryFilters()
            .Include(p => p.Producto)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (codeBar is null) return null!;

        return codeBar;
    }
}
