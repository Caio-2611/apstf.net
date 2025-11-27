namespace APS_Final.Domain.Entities
{
    // Marca (Lado 'Um' do relacionamento 1:N)
    public class Marca
    {
        public int Id { get; set; }
        
        // Propriedade para o nome da marca (ex: Volkswagen, Ford)
        public string Nome { get; set; }
        
        // Propriedade de navegação (Coleção) para o relacionamento 1:N
        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}