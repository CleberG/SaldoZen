namespace SaldoZen.Domain.Model
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        public DateTime? AlteradoEm { get; set; }
    }
}
