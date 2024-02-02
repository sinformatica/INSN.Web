namespace INSN.Web.Models.Response;

/// <summary>
/// Clase BaseResponse
/// </summary>
public class BaseResponse : AuditoriaResponse
{
    /// <summary>
    /// Success
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Error Message
    /// </summary>
    public string? ErrorMessage { get; set; }
}

/// <summary>
/// Clase BaseResponseGeneric
/// </summary>
public class BaseResponseGeneric<T> : BaseResponse
{
    /// <summary>
    /// Data
    /// </summary>
    public T? Data { get; set; }
}