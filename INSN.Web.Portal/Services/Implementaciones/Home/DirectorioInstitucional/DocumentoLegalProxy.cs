﻿using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

namespace INSN.Web.Portal.Services.Implementaciones.Home.DirectorioInstitucional;

/// <summary>
/// Clase Proxy Documento Legal
/// </summary>
public class DocumentoLegalProxy : CrudRestHelperBase<DocumentoLegalDtoRequest, DocumentoLegalDtoResponse>, IDocumentoLegalProxy
{
    public DocumentoLegalProxy(HttpClient httpClient)
        : base("api/DocumentoLegal", httpClient)
    {
    }

    /// <summary>
    /// Proxy: Documento Legal Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<DocumentoLegalDtoResponse>> DocumentoLegalListar(DocumentoLegalDtoRequest request)
    {           
        try
        {
            var queryString = $"?Documento={request.Documento}&Descripcion={request.Descripcion}&Area={request.Area}&CodigoTipoDocumentoId={request.CodigoTipoDocumentoId}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
            var response = await HttpClient.GetAsync($"{BaseUrl}/DocumentoLegalListar{queryString}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>>();

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