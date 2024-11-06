using Farmacity.Shared.DTOs.PaginationDtos;

namespace Farmacity.Shared.Extensions;

public static class IQueriableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDto paginationDto)
    {
        return queryable.Skip((paginationDto.PageNumber - 1) * paginationDto.PageSize)
            .Take(paginationDto.PageSize);
    }
}
