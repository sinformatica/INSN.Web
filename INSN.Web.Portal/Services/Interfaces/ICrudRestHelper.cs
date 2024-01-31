using INSN.Web.Models.Response;

namespace INSN.Web.Portal.Services.Interfaces;

public interface ICrudRestHelper<in TRequest, TResponse>
where TRequest : class
where TResponse : class
{
    Task<TResponse> FindByIdAsync(int id);

    Task CreateAsync(TRequest request);

    Task UpdateAsync(int id, TRequest request);

    Task DeleteAsync(int id);
}