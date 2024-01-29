﻿using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Mantenimiento.OportunidadLaboral;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.OportunidadLaboral;

namespace INSN.Web.Portal.Services.Implementaciones.Mantenimiento.OportunidadLaboral;

/// <summary>
/// Clase Proxy Documento Convocatoria
/// </summary>
public class DocumentoConvocatoriaProxy : CrudRestHelperBase<ConvocatoriaDtoRequest, DocumentoConvocatoriaDtoResponse>, IDocumentoConvocatoriaProxy
{
    public DocumentoConvocatoriaProxy(HttpClient httpClient)
        : base("api/Mantenimiento/OportunidadLaboral/DocumentoConvocatoria", httpClient)
    {
    }

    /// <summary>
    /// Proxy: Documento Convocatoria Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<DocumentoConvocatoriaDtoResponse>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request)
    {
        try
        {
            var queryString = $"?Descripcion={request.Descripcion}&CodigoTipoConvocatoriaId={request.CodigoTipoConvocatoriaId}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
            var response = await HttpClient.GetAsync($"{BaseUrl}/DocumentoConvocatoriaListar{queryString}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<DocumentoConvocatoriaDtoResponse>>>();

            if (result!.Success == false)
            {
                throw new InvalidOperationException(result.ErrorMessage);
            }

            return result.Data!;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}