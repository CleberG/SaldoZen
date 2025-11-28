using ModelContextProtocol;
using ModelContextProtocol.Server;
using SaldoZen.McpServer.HttpClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SaldoZen.McpServer.Tools
{
    [McpServerToolType]
    public static class PlanoContasTool
    {


        [McpServerToolType]
        public static class LivrariaTools
        {
            [McpServerTool, Description("Busca os planos de contas, definindo um filtro opcional por título")]
            public static async Task<string> ObterLivros(PlanoContasClient planoContasClient,
                [Description("Filtro opcional pelo título do livro")] string titulo)
            {
                try
                {
                    var livros = await planoContasClient.ObterPlanosContas(titulo);
                    return livros.Count == 0
                        ? "Nenhum livro encontrado"
                        : JsonSerializer.Serialize(livros);
                }
                catch (Exception ex)
                {
                    //Log
                    return $"Erro ao buscar livros: {ex.Message}";
                }
            }
        }
    }
}
