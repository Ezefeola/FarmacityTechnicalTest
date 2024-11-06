using Farmacity.Domain.Models;
using Farmacity.Shared.DTOs.PaginationDtos;

namespace Farmacity.Infrastructure.Repositories.Interfaces;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<Producto> GetByIdWithoutFilters(int id);
    Task<List<Producto>> GetProductsByStatus(PaginationDto paginationDto, bool? isActive = null);
}
