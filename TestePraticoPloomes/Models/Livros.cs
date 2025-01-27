namespace TestePraticoPloomes.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? MinhaResenha { get; set; }
        public string? Autor { get; set; }
        public string? Editora { get; set; }
        public int? Paginas { get; set; }
        public bool? Lido { get; set; }
    }
}
