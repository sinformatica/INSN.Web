using INSN.Web.Models.Response;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace INSN.Web.Portal.Services.Implementaciones
{
    /// <summary>
    /// RestBase
    /// </summary>
    public abstract class RestBase
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        protected readonly HttpClient HttpClient;

        /// <summary>
        /// Base Url
        /// </summary>
        protected string BaseUrl { get; set; }

        /// <summary>
        /// RestBase
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="httpClient"></param>
        protected RestBase(string baseUrl, HttpClient httpClient)
        {
            BaseUrl = baseUrl;
            HttpClient = httpClient;
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected async Task<TOutput> SendAsync<TInput, TOutput>(TInput request,
            HttpMethod method, string uri)
            where TOutput : BaseResponse
        {
            var requestMessage = new HttpRequestMessage(method, $"{BaseUrl}/{uri}");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8,
                MediaTypeNames.Application.Json);

            var response = await HttpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<TOutput>();
                return errorResponse!;
            }

            var result = await response.Content.ReadFromJsonAsync<TOutput>();
            if (result != null)
            {
                return result;
            }

            throw new InvalidOperationException($"Error en la solicitud {uri}");
        }
    }
}