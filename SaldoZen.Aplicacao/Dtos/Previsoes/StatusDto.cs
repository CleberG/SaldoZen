using SaldoZen.Aplicacao.Dtos.Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Aplicacao.Dtos.Previsoes
{
    public class StatusDto : EnumBase
    {
        public StatusDto() { }
        public StatusDto(int valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }
    }
}
