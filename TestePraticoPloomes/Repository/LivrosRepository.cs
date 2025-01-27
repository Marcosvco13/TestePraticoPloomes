using Microsoft.EntityFrameworkCore;
using TestePraticoPloomes.Context;
using TestePraticoPloomes.IRepository;
using TestePraticoPloomes.Models;

namespace TestePraticoPloomes.Repository
{
    public class LivrosRepository : BaseRepository, ILivrosRepository
    {
        public LivrosRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Livros>> GetBaseLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livros> GetLivroById(int id)
        {
            return await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddLivro(Livros livro)
        {
            await _context.Livros.AddAsync(livro);
        }

        public void UpdateLivro(Livros livro)
        {
            _context.Livros.Update(livro);
        }

        public void Delete(Livros livro)
        {
            _context.Livros.Remove(livro);
        }
    }
}
