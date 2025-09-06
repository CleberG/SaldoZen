namespace SaldoZen.Domain.ValueObject
{
    public class EmailCompleto : IValueObject<string>
    {
        public string Email { get; private set; }

        private EmailCompleto() { }

        public EmailCompleto(string email)
        {
            string emailValidar = string.Empty;

            if (email != null)
                emailValidar = email.Trim();

            Email = emailValidar;
        }

        public bool Equals(string? other)
        {
            return string.Equals(Email, other, StringComparison.OrdinalIgnoreCase);
        }
    }
}
