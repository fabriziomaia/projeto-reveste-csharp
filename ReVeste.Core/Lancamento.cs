namespace ReVeste.Core
{
    public class Lancamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamento Tipo { get; set; }
        public string? Descricao { get; set; }

        public int UsuarioId { get; set; }
        // CORREÇÃO: Adicionado '?' para indicar que a propriedade de navegação pode ser nula.
        public Usuario? Usuario { get; set; }
    }
}