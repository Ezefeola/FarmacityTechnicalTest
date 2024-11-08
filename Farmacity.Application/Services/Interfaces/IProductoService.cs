﻿using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.DTOs.Request.Producto;
using Farmacity.Shared.DTOs.Response.Producto;

namespace Farmacity.Application.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoResponseDto>> GetAllProductsByStatus(PaginationDto paginationDto, bool? isActive);
        Task<List<ProductoResponseDto>> GetAllProducts(PaginationDto paginationDto);
        Task<ProductoResponseDto> GetProductsById(int id);
        Task<ProductoCreateResponseDto> CreateProduct(ProductoCreateRequestDto productoCreateRequestDto, CancellationToken cancellationToken);
        Task<ProductoUpdateResponseDto> UpdateProduct(int id, ProductoUpdateRequestDto productoCreateRequestDto, CancellationToken cancellationToken);
        Task<ProductoResponseDto> DeleteProduct(int id);
        Task<ProductoResponseDto> SoftDeleteProduct(int id, CancellationToken cancellationToken);
        Task<ProductoResponseDto> RevertSoftDeletedProduct(int id, CancellationToken cancellationToken);
    }
}