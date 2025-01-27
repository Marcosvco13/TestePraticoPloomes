using TestePraticoPloomes.Models;

namespace TestePraticoPloomes.IRepository
{
    public interface ILivrosRepository
    {
        Task<IEnumerable<Livros>> GetBaseLivros();
        Task<Livros> GetLivroById(int id);
        Task AddLivro(Livros livro);
        void UpdateLivro(Livros livro);
        void Delete(Livros livro);
    }
}
