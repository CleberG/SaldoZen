using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.McpServer.DTOs
{
    public class PlanoContasResponde
    {
        public int Id { get; set; }

        public TipoResponse Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
