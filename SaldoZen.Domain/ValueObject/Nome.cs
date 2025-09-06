using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Domain.ValueObject
{
    public class Nome : IValueObject<string>
    {
        public string NomeCompleto { get; private set; }

        private Nome() { }

        public Nome(string nomeCompleto)
        {
            if (string.IsNullOrEmpty(nomeCompleto))
                throw new ArgumentNullException("nome ou sobrenome", "Nome e sobrenome são obrigatório");

            NomeCompleto = nomeCompleto;
        }

        public bool Equals(string? other)
        {
            return string.Equals(other, NomeCompleto, StringComparison.OrdinalIgnoreCase);
        }

        public string GetPrimairoNome(string value)
        {
            return value.Split(' ')[0];
        }

        public string GetIniciais(string value)
        {
            return String.Empty;
        }
    }
}
