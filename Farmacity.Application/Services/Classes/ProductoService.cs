using Farmacity.Application.Services.Interfaces;
using Farmacity.Application.Utilities.Mappers;
using Farmacity.Domain.Models;
using Farmacity.Infrastructure.UnitOfWork;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.DTOs.Request.Producto;
using Farmacity.Shared.DTOs.Response.Producto;

namespace Farmacity.Application.Services.Classes;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ProductoResponseDto>> GetAllProducts(PaginationDto paginationDto)
    {
        List<Producto> productsInDb = await _unitOfWork.ProductoRepository.GetAllWithPagination(paginationDto);

        List<ProductoResponseDto> productsInDbResponseDto = productsInDb
            .Select(ProductoMappers.MapToResponseDto)
            .ToList();

        return productsInDbResponseDto;
    }

    public async Task<ProductoResponseDto> GetProductsById(int id)
    {
        Producto productsInDb = await _unitOfWork.ProductoRepository.GetById(id);
        if (productsInDb is null) return null!;

        ProductoResponseDto productsInDbResponseDto = productsInDb.MapToResponseDto();

        return productsInDbResponseDto;
    }

    public async Task<ProductoCreateResponseDto> CreateProduct(ProductoCreateRequestDto productoCreateRequestDto, CancellationToken cancellationToken)
    {
        Producto productToCreate = productoCreateRequestDto.MapToModel();

        Producto createdProduct = await _unitOfWork.ProductoRepository.Create(productToCreate, cancellationToken);

        await _unitOfWork.Complete(cancellationToken);

        ProductoCreateResponseDto createdProductResponseDto = createdProduct.FromCreateToResponseDto();

        return createdProductResponseDto;
    }

    public async Task<ProductoUpdateResponseDto> UpdateProduct(int id, ProductoUpdateRequestDto productoCreateRequestDto, CancellationToken cancellationToken)
    {
        Producto productToUpdate = await _unitOfWork.ProductoRepository.GetById(id);

        ProductoMappers.MapToModel(productoCreateRequestDto, productToUpdate);

        Producto updatedProduct = await _unitOfWork.ProductoRepository.Update(id, productToUpdate);
        await _unitOfWork.Complete(cancellationToken);

        ProductoUpdateResponseDto updatedProductResponse = updatedProduct.FromUpdateToResponseDto();

        return updatedProductResponse;
    }

    public async Task<ProductoResponseDto> DeleteProduct(int id)
    {
        Producto productToDelete = await _unitOfWork.ProductoRepository.Delete(id);
        if (productToDelete is null) return null!;

        ProductoResponseDto deletedProductResponseDto = productToDelete.MapToResponseDto();

        return deletedProductResponseDto;
    }
}
