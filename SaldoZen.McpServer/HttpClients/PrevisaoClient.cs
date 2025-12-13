using SaldoZen.McpServer.DTOs;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace SaldoZen.McpServer.HttpClients
{
    public class PrevisaoClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public PrevisaoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<PrevisaoResponse>> ObterPrevisoes()
        {
            var url = "previsoes";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<PrevisaoResponse>();

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<List<PrevisaoResponse>>>(_jsonOptions);

            return apiResult is { IsSuccess: true, Data: not null } ? apiResult.Data : new List<PrevisaoResponse>();
        }

        public async Task<PrevisaoResponse> ObterPrevisaoPorId(int id)
        {
            var url = $"previsoes/{id}";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<PrevisaoResponse>>(_jsonOptions);

            return apiResult is { IsSuccess: true, Data: not null } ? apiResult.Data : null;
        }

        public async Task<PrevisaoResponse> CriarPrevisao(PrevisaoCreateRequest request)
        {
            try
            {
                var url = "previsoes";
                var response = await _httpClient.PostAsJsonAsync(url, request);

                response.EnsureSuccessStatusCode();

                //var jsonString = await response.Content.ReadAsStringAsync();

                var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<PrevisaoResponse>>(_jsonOptions);

                return apiResult is { IsSuccess: true, Data: not null } ? apiResult.Data : null;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            
        }

        public async Task<PrevisaoResponse> AtualizarPrevisao(int id, PrevisaoUpdateRequest request)
        {
            var url = $"previsoes/{id}";
            var response = await _httpClient.PutAsJsonAsync(url, request);

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<PrevisaoResponse>>(_jsonOptions);

            return apiResult is { IsSuccess: true, Data: not null } ? apiResult.Data : null;
        }

        public async Task<bool> DeletarPrevisao(int id)
        {
            var url = $"previsoes/{id}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }

        public async Task<BaixaResponse> AdicionarBaixa(int previsaoId, BaixaRequest request)
        {
            var url = $"previsoes/{previsaoId}/baixas";
            var response = await _httpClient.PostAsJsonAsync(url, request);

            response.EnsureSuccessStatusCode();

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<BaixaResponse>>(_jsonOptions);

            return apiResult is { IsSuccess: true, Data: not null } ? apiResult.Data : null;
        }
    }
}
