using Farmacity.Domain.Models;
using Farmacity.Shared.DTOs.Request.CodigoBarra;
using Farmacity.Shared.DTOs.Response.CodigoBarra;

namespace Farmacity.Application.Utilities.Mappers;

public static class CodigoBarraMappers
{
    public static CodigoBarra MapToModel(this CodigoBarraRequestDto codigoBarraRequestDto)
    {
        return new CodigoBarra
        {
            Activo = codigoBarraRequestDto.Activo,
            Codigo = codigoBarraRequestDto.Codigo,
            FechaModificacion = DateTime.Now
        };
    }

    public static CodigoBarra MapToModel(this CodigoBarraCreateRequestDto codigoBarraCreateRequestDto)
    {
        return new CodigoBarra
        {
            Activo = codigoBarraCreateRequestDto.Activo,
            Codigo = codigoBarraCreateRequestDto.Codigo
        };
    }

    public static CodigoBarra MapToModel(this CodigoBarraUpdateRequestDto codigoBarraUpdateRequestDto, CodigoBarra codigoBarra)
    {

        codigoBarra.Activo = codigoBarraUpdateRequestDto.Activo;
        codigoBarra.Codigo = codigoBarraUpdateRequestDto.Codigo;

        return codigoBarra;
    }

    public static CodigoBarraCreateResponseDto FromCreateToResponseDto(this CodigoBarra codigoBarra)
    {
        return new CodigoBarraCreateResponseDto
        {
            Id = codigoBarra.Id,
            ProductoId = codigoBarra.ProductoId,
            Activo = codigoBarra.Activo,
            Codigo = codigoBarra.Codigo,
            FechaAlta = codigoBarra.FechaAlta,
            FechaModificacion = codigoBarra.FechaModificacion
        };
    }

    public static CodigoBarraUpdateResponseDto FromUpdateToResponseDto(this CodigoBarra codigoBarra)
    {
        return new CodigoBarraUpdateResponseDto
        {
            ProductoId = codigoBarra.ProductoId,
            Activo = codigoBarra.Activo,
            Codigo = codigoBarra.Codigo,
            FechaAlta = codigoBarra.FechaAlta,
            FechaModificacion = codigoBarra.FechaModificacion
        };
    }

    public static CodigoBarraResponseDto MapToResponseDto(this CodigoBarra codigoBarra)
    {
        return new CodigoBarraResponseDto
        {
            ProductoId = codigoBarra.ProductoId,
            Activo = codigoBarra.Activo,
            Codigo = codigoBarra.Codigo,
            FechaAlta = codigoBarra.FechaAlta,
            FechaModificacion = codigoBarra.FechaModificacion
        };
    }

    public static void MapCodigosDeBarra(List<CodigoBarraRequestDto> codigoBarraRequestDto, List<CodigoBarra> codigoBarra)
    {
        Dictionary<string, CodigoBarra> existingCodes = codigoBarra.ToDictionary(cb => cb.Codigo);
        var newCodes = codigoBarraRequestDto.Where(dto => !existingCodes.ContainsKey(dto.Codigo))
                                      .Select(dto => new CodigoBarra
                                      {
                                          Codigo = dto.Codigo,
                                          Activo = dto.Activo,
                                          FechaAlta = DateTime.Now,
                                          FechaModificacion = DateTime.Now
                                      })
                                      .ToList();

        foreach (var codigoDto in codigoBarraRequestDto.Where(dto => existingCodes.ContainsKey(dto.Codigo)))
        {
            var codigoExistente = existingCodes[codigoDto.Codigo];
            codigoExistente.Activo = codigoDto.Activo;
            codigoExistente.FechaModificacion = DateTime.Now;
        }

        var codigosParaEliminar = codigoBarra.Where(cb => !codigoBarraRequestDto.Any(dto => dto.Codigo == cb.Codigo))
                                         .ToList();

        foreach (var codigo in newCodes)
        {
            codigoBarra.Add(codigo);
        }
        foreach (var codigo in codigosParaEliminar)
        {
            codigoBarra.Remove(codigo);
        }
    }
}
