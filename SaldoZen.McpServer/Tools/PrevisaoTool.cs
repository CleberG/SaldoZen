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

        [McpServerTool, Description("Cria uma nova previsão. A data de vencimento deve estar no formato YYYY-MM-DD.")]
        public static async Task<string> CriarPrevisao(
            PrevisaoClient client, 
            string descricao, 
            string valorOriginal, 
            string dataVencimento, 
            int categoriaId, 
            string observacoes = "")
        {
            try
            {
                if (!decimal.TryParse(valorOriginal, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var valorParsed))
                {
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'valorOriginal' não é um número válido. Use '.' como separador decimal." });
                }

                if (!DateTime.TryParse(dataVencimento, out var dataParsed))
                {
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'dataVencimento' não é uma data válida. Use o formato YYYY-MM-DD." });
                }

                var request = new PrevisaoCreateRequest { Descricao = descricao, ValorOriginal = valorParsed, DataVencimento = dataParsed, CategoriaId = categoriaId, Observacoes = observacoes };
                var previsao = await client.CriarPrevisao(request);
                return JsonSerializer.Serialize(previsao, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { erro = true, mensagem = ex.Message, detalhes = ex.ToString() });
            }
        }

        [McpServerTool, Description("Atualiza uma previsão existente. A data de vencimento deve estar no formato YYYY-MM-DD.")]
        public static async Task<string> AtualizarPrevisao(
            PrevisaoClient client, 
            int id, 
            string descricao, 
            string valorOriginal, 
            string dataVencimento, 
            int categoriaId, 
            string observacoes = "", 
            string juros = "0", 
            string multa = "0", 
            string desconto = "0")
        {
            try
            {
                if (!decimal.TryParse(valorOriginal, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var valorParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'valorOriginal' não é um número válido. Use '.' como separador decimal." });
                
                if (!DateTime.TryParse(dataVencimento, out var dataParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'dataVencimento' não é uma data válida. Use o formato YYYY-MM-DD." });

                if (!decimal.TryParse(juros, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var jurosParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'juros' não é um número válido. Use '.' como separador decimal." });

                if (!decimal.TryParse(multa, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var multaParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'multa' não é um número válido. Use '.' como separador decimal." });

                if (!decimal.TryParse(desconto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var descontoParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'desconto' não é um número válido. Use '.' como separador decimal." });

                var request = new PrevisaoUpdateRequest 
                { 
                    Descricao = descricao, 
                    ValorOriginal = valorParsed, 
                    DataVencimento = dataParsed, 
                    CategoriaId = categoriaId, 
                    Observacoes = observacoes, 
                    Juros = jurosParsed, 
                    Multa = multaParsed, 
                    Desconto = descontoParsed 
                };
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

        [McpServerTool, Description("Adiciona uma baixa (pagamento) a uma previsão. A data da baixa deve estar no formato YYYY-MM-DD.")]
        public static async Task<string> AdicionarBaixa(
            PrevisaoClient client, 
            int previsaoId, 
            string valorOriginal, 
            string dataBaixa, 
            string juros = "0", 
            string multa = "0", 
            string desconto = "0")
        {
            try
            {
                if (!decimal.TryParse(valorOriginal, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var valorParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'valorOriginal' não é um número válido. Use '.' como separador decimal." });

                if (!DateTime.TryParse(dataBaixa, out var dataParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'dataBaixa' não é uma data válida. Use o formato YYYY-MM-DD." });

                if (!decimal.TryParse(juros, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var jurosParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'juros' não é um número válido. Use '.' como separador decimal." });

                if (!decimal.TryParse(multa, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var multaParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'multa' não é um número válido. Use '.' como separador decimal." });

                if (!decimal.TryParse(desconto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var descontoParsed))
                    return JsonSerializer.Serialize(new { erro = true, mensagem = "O parâmetro 'desconto' não é um número válido. Use '.' como separador decimal." });

                var request = new BaixaRequest 
                { 
                    PrevisaoId = previsaoId, 
                    ValorOriginal = valorParsed, 
                    DataBaixa = dataParsed,
                    Juros = jurosParsed,
                    Multa = multaParsed,
                    Desconto = descontoParsed
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
