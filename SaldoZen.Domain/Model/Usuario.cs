using SaldoZen.Domain.Enun;
using SaldoZen.Domain.ValueObject;

namespace SaldoZen.Domain.Model
{
    public class Usuario : EntityBase
    {
        /// <summary>
        /// Nome completo do usuário
        /// </summary>
        public Nome Nome { get; private set; }

        /// <summary>
        /// CPF do usuário
        /// </summary>
        public string CPF { get; private set; }

        /// <summary>
        /// Data nascimento do usuário
        /// </summary>
        public DateTime? DataNascimento { get; private set; }

        /// <summary>
        /// Login de acesso ao sistema para o usuário
        /// </summary>
        public EmailCompleto Login { get; private set; }

        /// <summary>
        /// Value object senha do usuário
        /// </summary>
        public Senha? Senha { get; set; }

        public string Role { get; private set; }

        /// <summary>
        /// Status do usuário
        /// </summary>
        public EUsuarioStatus Status { get; set; }

        public Usuario() { }

        public Usuario(Nome nome, DateTime dataNascimento, EmailCompleto login, Senha? senha, string role)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Login = login;
            Senha = senha;
            Role = role;
            CPF = string.Empty; // Inicializa CPF como vazio, pode ser alterado posteriormente
        }
    }
}
