namespace INSN.Web.Portal.Services.Interfaces;

/// <summary>
/// ICrudRestHelper
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface ICrudRestHelper<in TRequest, TResponse>
where TRequest : class
where TResponse : class
{
    /// <summary>
    /// FindByIdAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TResponse> FindByIdAsync(int id);

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task CreateAsync(TRequest request);

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task UpdateAsync(int id, TRequest request);

    /// <summary>
    /// DeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(int id);
}