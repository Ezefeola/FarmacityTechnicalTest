using Farmacity.Application.Services.Interfaces;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.DTOs.Request.CodigoBarra;
using Farmacity.Shared.DTOs.Response.CodigoBarra;
using Microsoft.AspNetCore.Mvc;

namespace Farmacity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CodigoBarraController : ControllerBase
{
    private readonly ICodigoBarraService _codigoBarraService;
    private readonly IProductoService _productoService;

    public CodigoBarraController
        (
            ICodigoBarraService codigoBarraService,
            IProductoService productoService
        )
    {
        _codigoBarraService = codigoBarraService;
        _productoService = productoService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDto paginationDto)
    {
        List<CodigoBarraResponseDto> obtainedCodeBarsResponse = await _codigoBarraService.GetAllCodeBars(paginationDto);
        return Ok(obtainedCodeBarsResponse);
    }

    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        try
        {
            List<CodigoBarraResponseDto> obtainedProductResponse = await _codigoBarraService.GetCodeBarsByIdAsync(id);

            return Ok(obtainedProductResponse);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost("create/{productId:int}")]
    public async Task<IActionResult> Create(int productId, [FromBody] CodigoBarraCreateRequestDto codigoBarraCreateRequestDto, CancellationToken cancellationToken)
    {
        try
        {
            var productExists = await _productoService.GetProductsById(productId);
            if (productExists is null) return NotFound("No se encontro el producto al que se quiere añadir el codigo de barra.");

            CodigoBarraCreateResponseDto createdCodeBar = await _codigoBarraService.CreateCodeBar(productId, codigoBarraCreateRequestDto, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = createdCodeBar.Id }, createdCodeBar);
        }
        catch (Exception)
        {

            return BadRequest("No pudo crearse el registro.");
        }
    }

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CodigoBarraUpdateRequestDto productoUpdateRequestDto, CancellationToken cancellationToken)
    {
        try
        {
            CodigoBarraUpdateResponseDto updatedProduct = await _codigoBarraService.UpdateCodeBar(id, productoUpdateRequestDto, cancellationToken);

            return Ok(updatedProduct);
        }
        catch (Exception)
        {

            return BadRequest("Hubo un error");
        }
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        try
        {
            CodigoBarraResponseDto deletedCodeBar = await _codigoBarraService.DeleteCodeBar(id);
            if (deletedCodeBar is null) return NotFound($"No se encontro el codigo de barra con id: {id}");

            return Ok(deletedCodeBar);
        }
        catch (Exception)
        {
            return BadRequest($"No se pudo eliminar el registro.");
        }
    }
}
