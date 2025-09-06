namespace SaldoZen.Domain.ValueObject
{
    public class Senha : IValueObject<string>
    {
        public string SenhaHash { get; private set; }
        public string SenhaFake { get => "fakepass"; }

        private Senha() { }

        public Senha(string senha)
        {
            SenhaHash = AlterouSenha(senha) ? senha : SenhaFake;
        }

        public Senha(string senha, string confirmarSenha) : this(senha)
        {
            if (!SenhaFake.Equals(senha) && !string.Equals(confirmarSenha, confirmarSenha))
                throw new ArgumentException("Senhas não são iguais");
        }

        public bool Equals(string? other)
        {
            return SenhaHash.Equals(other);
        }

        public bool AlterouSenha(string senha)
        {
            return !SenhaFake.Equals(senha, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return SenhaHash;
        }
    }
}
