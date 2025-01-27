using System.ComponentModel.DataAnnotations;

namespace TestePraticoPloomes.Resources
{
    public class SaveLivrosResource
    {
        [StringLength(255)]
        public string? Titulo { get; set; }
        [StringLength(2555)]
        public string? MinhaResenha { get; set; }
        [StringLength(255)]
        public string? Autor { get; set; }
        [StringLength(255)]
        public string? Editora { get; set; }
        public int? Paginas { get; set; }
        public bool? Lido { get; set; }
    }
}
