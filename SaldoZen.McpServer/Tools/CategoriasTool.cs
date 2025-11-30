using ModelContextProtocol.Server;
using SaldoZen.McpServer.HttpClients;
using System.ComponentModel;
using System.Text.Json;

namespace SaldoZen.McpServer.Tools
{

    [McpServerToolType]
    public static class CategoriasTools
    {
        [McpServerTool, Description("Busca e retorna todas as Categorias cadastradams no sistema.")]
        public static async Task<string> ObterCategorias(CategoriasClient planoContasClient)
        {
            try
            {
                var planosContas = await planoContasClient.ObterCategorias();
                return JsonSerializer.Serialize(planosContas, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new
                {
                    erro = true,
                    mensagem = ex.Message,
                    detalhes = ex.ToString()
                });
            }
        }
    }
}
