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

        public async Task<CategoriasResponde> AdicionarCategoria(CategoriaRequest request)
        {
            var url = "categorias";
            var response = await _httpClient.PostAsJsonAsync(url, request);

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<CategoriasResponde>>(_jsonOptions);

            if (apiResult != null && apiResult.IsSuccess && apiResult.Data != null)
            {
                return apiResult.Data;
            }

            return null;
        }

        public async Task<CategoriasResponde> AtualizarCategoria(CategoriaRequest request)
        {
            var url = "categorias";
            var response = await _httpClient.PutAsJsonAsync(url, request);

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<CategoriasResponde>>(_jsonOptions);

            if (apiResult != null && apiResult.IsSuccess && apiResult.Data != null)
            {
                return apiResult.Data;
            }

            return null;
        }

        public async Task<CategoriasResponde> ObterCategoriaPorId(int id)
        {
            var url = $"categorias/{id}";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<CategoriasResponde>>(_jsonOptions);

            if (apiResult != null && apiResult.IsSuccess && apiResult.Data != null)
            {
                return apiResult.Data;
            }

            return null;
        }

        public async Task<List<CategoriasResponde>> ObterCategoriasPorDescricao(string descricao)
        {
            var url = $"categorias/descricao?descricao={descricao}";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<CategoriasResponde>();

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<List<CategoriasResponde>>>(_jsonOptions);

            if (apiResult != null && apiResult.IsSuccess && apiResult.Data != null)
            {
                return apiResult.Data;
            }

            return new List<CategoriasResponde>();
        }

        public async Task<ApiResult<object>> DeletarCategoria(int id)
        {
            var url = $"categorias/{id}";
            var response = await _httpClient.DeleteAsync(url);

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<object>>(_jsonOptions);

            if (apiResult != null && apiResult.IsSuccess)
            {
                return apiResult;
            }

            return new ApiResult<object> { IsSuccess = false, Message = "Falha ao deletar categoria." };
        }
    }
}
