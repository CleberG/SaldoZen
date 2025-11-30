using SaldoZen.McpServer.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace SaldoZen.McpServer.HttpClients
{
    public class CategoriasClient
    {
        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _jsonOptions;

        public CategoriasClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<CategoriasResponde>> ObterCategorias()
        {
            var url = "categorias";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<CategoriasResponde>();

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<List<CategoriasResponde>>>(_jsonOptions);

            if (apiResult != null && apiResult.IsSuccess && apiResult.Data != null)
            {
                return apiResult.Data;
            }

            // Return empty list if call was not successful or data is null
            return new List<CategoriasResponde>();
        }
    }
}
