﻿namespace INSN.Web.Models.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    public string? Estado { get; set; }

    public string? Data { get; set; }
}

public class BaseResponseGeneric<T> : BaseResponse
{
    public T? Data { get; set; }
}

public class PaginationResponse<T> : BaseResponse
{
    public ICollection<T>? Data { get; set; }
    public int TotalPages { get; set; }
}