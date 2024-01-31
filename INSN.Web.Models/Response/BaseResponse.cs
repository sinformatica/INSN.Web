namespace INSN.Web.Models.Response;

/// <summary>
/// Clase BaseResponse
/// </summary>
public class BaseResponse : AuditoriaResponse
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

/// <summary>
/// Clase BaseResponseGeneric
/// </summary>
public class BaseResponseGeneric<T> : BaseResponse
{
    public T? Data { get; set; }
}