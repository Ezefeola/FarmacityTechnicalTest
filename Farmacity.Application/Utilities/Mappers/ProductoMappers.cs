using Farmacity.Domain.Models;
using Farmacity.Shared.DTOs.Request.Producto;
using Farmacity.Shared.DTOs.Response.CodigoBarra;
using Farmacity.Shared.DTOs.Response.Producto;

namespace Farmacity.Application.Utilities.Mappers;

public static class ProductoMappers
{

    public static Producto MapToModel(this ProductoCreateRequestDto productoCreateRequestDto)
    {
        return new Producto
        {
            Nombre = productoCreateRequestDto.Nombre,
            Precio = productoCreateRequestDto.Precio,
            Activo = productoCreateRequestDto.Activo,
            CantidadEnStock = productoCreateRequestDto.CantidadEnStock,
            CodigosBarras = productoCreateRequestDto.CodigosBarraRequestDto?.Select(cb => new CodigoBarra
            {
                Codigo = cb.Codigo,
                Activo = cb.Activo
            }).ToList()    
        };
    }

    public static Producto MapToModel(this ProductoUpdateRequestDto productoUpdateRequestDto, Producto producto)
    {

        producto.Nombre = productoUpdateRequestDto.Nombre;
        producto.Precio = productoUpdateRequestDto.Precio;
        producto.Activo = productoUpdateRequestDto.Activo;
        producto.CantidadEnStock = productoUpdateRequestDto.CantidadEnStock;
        producto.FechaModificacion = DateTime.Now;

        CodigoBarraMappers.MapCodigosDeBarra(productoUpdateRequestDto.CodigoBarraRequestDto!, producto.CodigosBarras!);
        return producto;
    }

    public static ProductoResponseDto MapToResponseDto(this Producto producto)
    {
        return new ProductoResponseDto
        {
            Id = producto.Id,   
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Activo = producto.Activo,
            CantidadEnStock = producto.CantidadEnStock,
            FechaAlta = producto.FechaAlta,
            FechaModificacion = producto.FechaModificacion,
            CodigoBarraResponseDto = producto.CodigosBarras?.Select(cb => new CodigoBarraResponseDto
            {
                ProductoId = producto.Id,   
                Codigo = cb.Codigo,
                Activo = cb.Activo
            }).ToList()
        };
    }

    public static ProductoCreateResponseDto FromCreateToResponseDto(this Producto producto)
    {
        return new ProductoCreateResponseDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Activo = producto.Activo,
            CantidadEnStock = producto.CantidadEnStock,
            FechaAlta = producto.FechaAlta,
            CodigoBarraResponseDto = producto.CodigosBarras?.Select(cb => new CodigoBarraResponseDto
            {
                ProductoId = producto.Id,
                Codigo = cb.Codigo,
                Activo = cb.Activo
            }).ToList()
        };
    }
    public static ProductoUpdateResponseDto FromUpdateToResponseDto(this Producto producto)
    {
        return new ProductoUpdateResponseDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Activo = producto.Activo,
            CantidadEnStock = producto.CantidadEnStock,
            FechaAlta = producto.FechaAlta,
            FechaModificacion = producto.FechaModificacion,
            CodigoBarraResponseDto = producto.CodigosBarras?.Select(cb => new CodigoBarraResponseDto
            {
                ProductoId = producto.Id,
                Codigo = cb.Codigo,
                Activo = cb.Activo
            }).ToList()
        };
    }
}
