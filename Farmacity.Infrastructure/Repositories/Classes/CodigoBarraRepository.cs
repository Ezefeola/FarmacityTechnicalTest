using Farmacity.Domain.Models;
using Farmacity.Infrastructure.Data;
using Farmacity.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacity.Infrastructure.Repositories.Classes;

public class CodigoBarraRepository : GenericRepository<CodigoBarra>, ICodigoBarraRepository
{
    public CodigoBarraRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<List<CodigoBarra>> GetCodeBarsById(int id)
    {
        List<CodigoBarra> recordsDb = await _dbSet.Where(x => x.ProductoId == id).ToListAsync();
        return recordsDb!;
    }
}
