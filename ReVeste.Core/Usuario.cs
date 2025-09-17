namespace ReVeste.Core
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Inicializado
        public string Email { get; set; } = string.Empty; // Inicializado

        public ICollection<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
    }
}