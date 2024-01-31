namespace INSN.Web.Models.Request.Home.DocumentoLegal;

/// <summary>
/// Clase TipoDocumentoDtoRequest
/// </summary>
public class TipoDocumentoDtoRequest : AuditoriaRequest
{
    /// <summary>
    /// Codigo Tipo Documento
    /// </summary>
    public int CodigoTipoDocumentoId { get; set; }

    /// <summary>
    /// Descripcion Tipo Documento
    /// </summary>
    public string? Descripcion { get; set; } = default!;

    /// <summary>
    /// Area
    /// </summary>
    public string? Area { get; set; } = default!;
}