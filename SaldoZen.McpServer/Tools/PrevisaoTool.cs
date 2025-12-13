using ModelContextProtocol.Server;
using SaldoZen.McpServer.DTOs;
using SaldoZen.McpServer.HttpClients;
using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace SaldoZen.McpServer.Tools
{
    [McpServerToolType]
    public static class PrevisaoTools
    {
        [McpServerTool, Description("Busca e retorna todas as previsões cadastradas.")]
        public static async Task<string> ObterPrevisoes(PrevisaoClient client)
        {
            try
            {
                var previsoes = await client.ObterPrevisoes();
                return JsonSerializer.Serialize(previsoes, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }

        [McpServerTool, Description("Busca e retorna uma previsão pelo seu ID.")]
        public static async Task<string> ObterPrevisaoPorId(PrevisaoClient client, int id)
        {
            try
            {
                var previsao = await client.ObterPrevisaoPorId(id);
                return JsonSerializer.Serialize(previsao, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }

        [McpServerTool, Description("Cria uma nova previsão.")]
        public static async Task<string> CriarPrevisao(PrevisaoClient client, string descricao, decimal valor, DateTime dataVencimento, int categoriaId)
        {
            try
            {
                var request = new PrevisaoRequest { Descricao = descricao, ValorOriginal = valor, DataVencimento = dataVencimento, CategoriaId = categoriaId };
                var previsao = await client.CriarPrevisao(request);
                return JsonSerializer.Serialize(previsao, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }

        [McpServerTool, Description("Atualiza uma previsão existente.")]
        public static async Task<string> AtualizarPrevisao(PrevisaoClient client, int id, string descricao, decimal valor, DateTime dataVencimento, int categoriaId)
        {
            try
            {
                var request = new PrevisaoRequest { Descricao = descricao, ValorOriginal = valor, DataVencimento = dataVencimento, CategoriaId = categoriaId };
                var previsao = await client.AtualizarPrevisao(id, request);
                return JsonSerializer.Serialize(previsao, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }

        [McpServerTool, Description("Deleta uma previsão pelo seu ID.")]
        public static async Task<string> DeletarPrevisao(PrevisaoClient client, int id)
        {
            try
            {
                var sucesso = await client.DeletarPrevisao(id);
                return JsonSerializer.Serialize(new { sucesso });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }

        [McpServerTool, Description("Adiciona uma baixa (pagamento) a uma previsão.")]
        public static async Task<string> AdicionarBaixa(PrevisaoClient client, int previsaoId, decimal valorOriginal, DateTime dataBaixa, decimal juros = 0, decimal multa = 0, decimal desconto = 0)
        {
            try
            {
                var request = new BaixaRequest 
                { 
                    PrevisaoId = previsaoId, 
                    ValorOriginal = valorOriginal, 
                    DataBaixa = dataBaixa,
                    Juros = juros,
                    Multa = multa,
                    Desconto = desconto
                };
                var baixa = await client.AdicionarBaixa(previsaoId, request);
                return JsonSerializer.Serialize(baixa, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }
    }
}
