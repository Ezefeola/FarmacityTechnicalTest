using Farmacity.Application.Services.Interfaces;
using Farmacity.Application.Utilities.Mappers;
using Farmacity.Domain.Models;
using Farmacity.Infrastructure.UnitOfWork;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.DTOs.Request.CodigoBarra;
using Farmacity.Shared.DTOs.Response.CodigoBarra;

namespace Farmacity.Application.Services.Classes;

public class CodigoBarraService : ICodigoBarraService
{
    private readonly IUnitOfWork _unitOfWork;

    public CodigoBarraService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CodigoBarraResponseDto>> GetAllCodeBars(PaginationDto paginationDto)
    {
        List<CodigoBarra> codebarsInDb = await _unitOfWork.CodigoBarraRepository.GetAllWithPagination(paginationDto);

        List<CodigoBarraResponseDto> codebarsInDbResponseDto = codebarsInDb
            .Select(CodigoBarraMappers.MapToResponseDto)
            .ToList();

        return codebarsInDbResponseDto;
    }

    public async Task<List<CodigoBarraResponseDto>> GetCodeBarsByIdAsync(int id)
    {
        List<CodigoBarra> codigoBarraInDb = await _unitOfWork.CodigoBarraRepository.GetCodeBarsById(id);

        List<CodigoBarraResponseDto> codigoBarraInDbResponseDto = codigoBarraInDb
            .Select(CodigoBarraMappers.MapToResponseDto)
            .ToList();

        return codigoBarraInDbResponseDto;
    }

    public async Task<CodigoBarraCreateResponseDto> CreateCodeBar(int productId, CodigoBarraCreateRequestDto codigoBarraCreateRequestDto, CancellationToken cancellationToken)
    {
        CodigoBarra codeBarToCreate = codigoBarraCreateRequestDto.MapToModel();
        codeBarToCreate.ProductoId = productId;

        CodigoBarra createdCodeBar = await _unitOfWork.CodigoBarraRepository.Create(codeBarToCreate, cancellationToken);

        await _unitOfWork.Complete(cancellationToken);

        CodigoBarraCreateResponseDto createdCodeBarResponseDto = createdCodeBar.FromCreateToResponseDto();

        return createdCodeBarResponseDto;
    }

    public async Task<CodigoBarraUpdateResponseDto> UpdateCodeBar(int id, CodigoBarraUpdateRequestDto codigoBarraUpdateRequestDto, CancellationToken cancellationToken)
    {
        CodigoBarra codeBarToUpdate = await _unitOfWork.CodigoBarraRepository.GetById(id);
        
        CodigoBarraMappers.MapToModel(codigoBarraUpdateRequestDto, codeBarToUpdate);

        CodigoBarra updatedCodebar = await _unitOfWork.CodigoBarraRepository.Update(id, codeBarToUpdate);
        await _unitOfWork.Complete(cancellationToken);

        CodigoBarraUpdateResponseDto updatedCodeBarResponse = updatedCodebar.FromUpdateToResponseDto();

        return updatedCodeBarResponse;
    }

    public async Task<CodigoBarraResponseDto> DeleteCodeBar(int id)
    {
        CodigoBarra codeBarToDelete = await _unitOfWork.CodigoBarraRepository.Delete(id);
        if (codeBarToDelete is null) return null!;
        CodigoBarraResponseDto deletedCodeBarResponseDto = codeBarToDelete.MapToResponseDto();

        return deletedCodeBarResponseDto;
    }
}
