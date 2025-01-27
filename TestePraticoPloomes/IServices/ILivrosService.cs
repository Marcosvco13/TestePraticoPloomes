using TestePraticoPloomes.Communication;
using TestePraticoPloomes.Models;

namespace TestePraticoPloomes.IServices
{
    public interface ILivrosService
    {
        Task<IEnumerable<Livros>> GetBaseLivros();
        Task<Livros> GetLivroById(int id);
        Task<LivrosResponse> AddLivro(Livros livro);
        Task<LivrosResponse> UpdateLivro(int id, Livros livro);
        Task<LivrosResponse> Delete(int id);
    }
}
