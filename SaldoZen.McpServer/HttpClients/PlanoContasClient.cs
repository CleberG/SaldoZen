using SaldoZen.McpServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SaldoZen.McpServer.HttpClients
{
    public class PlanoContasClient
    {
        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _jsonOptions;

        public PlanoContasClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<PlanoContasResponde>> ObterPlanosContas(string? titulo = null)
        {
            var url = "PlanoContas";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<PlanoContasResponde>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PlanoContasResponde>>(_jsonOptions);
        }
    }
}
