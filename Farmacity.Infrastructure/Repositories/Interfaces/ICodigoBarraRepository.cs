using Farmacity.Domain.Models;
using Farmacity.Shared.DTOs.PaginationDtos;

namespace Farmacity.Infrastructure.Repositories.Interfaces;

public interface ICodigoBarraRepository : IGenericRepository<CodigoBarra>
{
    Task<List<CodigoBarra>> GetCodeBarsWithFilters(PaginationDto paginationDto, bool? isActive = null);
    Task<List<CodigoBarra>> GetCodeBarsById(int id);
    Task<CodigoBarra> GetByIdWithoutFilters(int id);
}
