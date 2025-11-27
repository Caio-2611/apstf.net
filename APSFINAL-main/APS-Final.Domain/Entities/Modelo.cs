namespace APS_Final.Domain.Entities
{
    // Modelo (Lado 'Muitos' do relacionamento 1:N)
    public class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; } // Adicionando um campo simples para validação futura
        
        // Chave Estrangeira (FK) explícita
        public int MarcaId { get; set; }
        
        // Propriedade de navegação para a Entidade 'Um'
        public Marca Marca { get; set; }
    }
}