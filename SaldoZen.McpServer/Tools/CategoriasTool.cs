using ModelContextProtocol.Server;
using SaldoZen.McpServer.DTOs;
using SaldoZen.McpServer.HttpClients;
using System.ComponentModel;
using System.Text.Json;

namespace SaldoZen.McpServer.Tools
{

    [McpServerToolType]
    public static class CategoriasTools
    {
        [McpServerTool, Description("Busca e retorna todas as Categorias cadastradas no sistema.")]
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

        [McpServerTool, Description("Adiciona uma nova categoria no sistema.")]
        public static async Task<string> AdicionarCategoria(CategoriasClient client, string descricao, int tipo)
        {
            try
            {
                var request = new CategoriaRequest { Descricao = descricao, Tipo = tipo };
                var categoria = await client.AdicionarCategoria(request);
                return JsonSerializer.Serialize(categoria, new JsonSerializerOptions
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

        [McpServerTool, Description("Atualiza uma categoria existente no sistema.")]
        public static async Task<string> AtualizarCategoria(CategoriasClient client, int id, string descricao, int tipo)
        {
            try
            {
                var request = new CategoriaRequest { Id = id, Descricao = descricao, Tipo = tipo };
                var categoria = await client.AtualizarCategoria(request);
                return JsonSerializer.Serialize(categoria, new JsonSerializerOptions
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

        [McpServerTool, Description("Busca e retorna uma categoria pelo seu ID.")]
        public static async Task<string> ObterCategoriaPorId(CategoriasClient client, int id)
        {
            try
            {
                var categoria = await client.ObterCategoriaPorId(id);
                return JsonSerializer.Serialize(categoria, new JsonSerializerOptions
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

        [McpServerTool, Description("Busca e retorna todas as categorias que correspondem à descrição fornecida.")]
        public static async Task<string> ObterCategoriasPorDescricao(CategoriasClient client, string descricao)
        {
            try
            {
                var categorias = await client.ObterCategoriasPorDescricao(descricao);
                return JsonSerializer.Serialize(categorias, new JsonSerializerOptions
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
