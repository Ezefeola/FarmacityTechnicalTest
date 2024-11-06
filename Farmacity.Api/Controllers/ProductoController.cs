using Farmacity.Application.Services.Interfaces;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.DTOs.Request.Producto;
using Farmacity.Shared.DTOs.Response.Producto;
using Microsoft.AspNetCore.Mvc;

namespace Farmacity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet("getAllByStatus")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDto paginationDto, bool? isActive)
    {
        List<ProductoResponseDto> obtainedProductsResponse = await _productoService.GetAllProductsByStatus(paginationDto, isActive);
        return Ok(obtainedProductsResponse);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDto paginationDto)
    {
        List<ProductoResponseDto> obtainedProductsResponse = await _productoService.GetAllProducts(paginationDto);
        return Ok(obtainedProductsResponse);
    }

    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            ProductoResponseDto obtainedProductResponse = await _productoService.GetProductsById(id);

            if (obtainedProductResponse is null) return NotFound($"No se encontro el producto con id: {id} para eliminar.");

            return Ok(obtainedProductResponse);
        }
        catch (Exception)
        {

            return NotFound($"No se encontro el producto con id: {id}");
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ProductoCreateRequestDto productoCreateRequestDto, CancellationToken cancellationToken)
    {
        try
        {
            ProductoCreateResponseDto createdProduct = await _productoService.CreateProduct(productoCreateRequestDto, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id}, createdProduct);  
        }
        catch (Exception)
        {

            return BadRequest("No pudo crearse el registro.");
        }
    }

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductoUpdateRequestDto productoUpdateRequestDto, CancellationToken cancellationToken)
    {
        try
        {
            var productExists = await _productoService.GetProductsById(id);
            if (productExists is null) return NotFound($"No se encontro el producto con id: {id} para actualizar.");

            ProductoUpdateResponseDto updatedProduct = await _productoService.UpdateProduct(id, productoUpdateRequestDto, cancellationToken);


            return Ok(updatedProduct);
        }
        catch (Exception)
        {

            return BadRequest("No se pudo actualizar el registro.");
        }
    }

    [HttpPut("softDelete/{id:int}")]
    public async Task<IActionResult> SoftDelete(int id, CancellationToken cancellationToken)
    {
        try
        {
            ProductoResponseDto deletedProduct = await _productoService.SoftDeleteProduct(id, cancellationToken);

            if (deletedProduct is null) return NotFound($"No se encontro el producto con id: {id} para eliminar.");

            return Ok(deletedProduct);
        }
        catch (Exception)
        {
            return BadRequest("No se pudo eliminar el registro");
        }
    }

    [HttpPut("revertSoftDelete/{id:int}")]
    public async Task<IActionResult> RevertSoftDelete(int id, CancellationToken cancellationToken)
    {
        try
        {
            ProductoResponseDto deletedProduct = await _productoService.RevertSoftDeletedProduct(id, cancellationToken);

            if (deletedProduct is null) return NotFound($"No se encontro el producto con id: {id} para habilitar o ya esta activo.");

            return Ok(deletedProduct);
        }
        catch (Exception)
        {
            return BadRequest("No se pudo habilitar el registro");
        }
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            ProductoResponseDto deletedProduct = await _productoService.DeleteProduct(id);

            if (deletedProduct is null) return NotFound($"No se encontro el producto con id: {id} para eliminar.");

            return Ok(deletedProduct);
        }
        catch (Exception)
        {
            return BadRequest("No se pudo eliminar el registro");   
        }
    }
}
