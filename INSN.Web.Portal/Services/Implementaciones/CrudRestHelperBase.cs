using INSN.Web.Models.Response;
using INSN.Web.Portal.Services.Interfaces;

namespace INSN.Web.Portal.Services.Implementaciones;

/// <summary>
/// Clase Crud Rest Helper Base
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class CrudRestHelperBase<TRequest, TResponse> : RestBase, ICrudRestHelper<TRequest, TResponse>
where TRequest : class
where TResponse : class
{
    /// <summary>
    /// Crud Rest Helper Base
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="httpClient"></param>
    public CrudRestHelperBase(string baseUrl, HttpClient httpClient) : base(baseUrl, httpClient)
    {
    }

    /// <summary>
    /// FindByIdAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<TResponse> FindByIdAsync(int id)
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<TResponse>>($"{BaseUrl}/{id}");
        if (response!.Success)
        {
            return response.Data!;
        }

        throw new InvalidOperationException(response.ErrorMessage);
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task CreateAsync(TRequest request)
    {
        var response = await HttpClient.PostAsJsonAsync(BaseUrl, request);
        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false)
                throw new InvalidOperationException(resultado.ErrorMessage);
        }
        else
        {
            throw new InvalidOperationException(response.ReasonPhrase);
        }
    }

    /// <summary>
    /// Update Async
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task UpdateAsync(int id, TRequest request)
    {
        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/{id}", request);
        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false)
                throw new InvalidOperationException(resultado.ErrorMessage);
        }
        else
        {
            throw new InvalidOperationException(response.ReasonPhrase);
        }
    }

    /// <summary>
    /// Delete Async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task DeleteAsync(int id)
    {
        var response = await HttpClient.DeleteAsync($"{BaseUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false)
                throw new InvalidOperationException(resultado.ErrorMessage);
        }
        else
        {
            throw new InvalidOperationException(response.ReasonPhrase);
        }
    }
}