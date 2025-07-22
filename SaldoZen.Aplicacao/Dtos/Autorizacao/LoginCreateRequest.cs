using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Aplicacao.Dtos.Autorizacao
{
    public class LoginCreateRequest
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
