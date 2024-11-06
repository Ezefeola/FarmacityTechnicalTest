using Farmacity.Domain.Models;

namespace Farmacity.Infrastructure.Repositories.Interfaces;

public interface ICodigoBarraRepository : IGenericRepository<CodigoBarra>
{
    Task<List<CodigoBarra>> GetCodeBarsById(int id);
}
