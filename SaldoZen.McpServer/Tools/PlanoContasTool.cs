using ModelContextProtocol.Server;
using SaldoZen.McpServer.HttpClients;
using System.ComponentModel;
using System.Text.Json;

namespace SaldoZen.McpServer.Tools
{

    [McpServerToolType]
    public static class PlanoContasTools
    {
        [McpServerTool, Description("Busca e retorna todos os planos de contas cadastrados no sistema.")]
        public static async Task<string> ObterPlanosContas(PlanoContasClient planoContasClient)
        {
            try
            {
                var planosContas = await planoContasClient.ObterPlanosContas();
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
