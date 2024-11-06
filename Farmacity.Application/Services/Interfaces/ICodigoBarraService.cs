using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.DTOs.Request.CodigoBarra;
using Farmacity.Shared.DTOs.Response.CodigoBarra;

namespace Farmacity.Application.Services.Interfaces
{
    public interface ICodigoBarraService
    {
        Task<List<CodigoBarraResponseDto>> GetAllCodeBars(PaginationDto paginationDto);
        Task<List<CodigoBarraResponseDto>> GetCodeBarsByIdAsync(int id);
        Task<CodigoBarraCreateResponseDto> CreateCodeBar(int productId, CodigoBarraCreateRequestDto codigoBarraCreateRequestDto, CancellationToken cancellationToken);
        Task<CodigoBarraUpdateResponseDto> UpdateCodeBar(int id, CodigoBarraUpdateRequestDto codigoBarraUpdateRequestDto, CancellationToken cancellationToken);
        Task<CodigoBarraResponseDto> DeleteCodeBar(int id);
    }
}