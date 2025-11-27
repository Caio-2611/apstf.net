namespace APS_Final.Application.ViewModels
{
    public class ModeloViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int MarcaId { get; set; }
        public string MarcaNome { get; set; } // Para exibir o nome da Marca na listagem
    }
}