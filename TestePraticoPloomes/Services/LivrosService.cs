using TestePraticoPloomes.Communication;
using TestePraticoPloomes.IRepository;
using TestePraticoPloomes.IServices;
using TestePraticoPloomes.Models;

namespace TestePraticoPloomes.Services
{
    public class LivrosService : ILivrosService
    {
        private readonly ILivrosRepository _livrosRepository;
        private readonly IUnitOFWork _unitOfWork;

        public LivrosService(ILivrosRepository livrosRepository, IUnitOFWork unitOfWork)
        {
            this._livrosRepository = livrosRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Livros>> GetBaseLivros()
        {
            return await _livrosRepository.GetBaseLivros();
        }

        public async Task<Livros> GetLivroById(int id)
        {
            return await _livrosRepository.GetLivroById(id);
        }

        public async Task<LivrosResponse> AddLivro(Livros livro)
        {
            try
            {
                await _livrosRepository.AddLivro(livro);
                await _unitOfWork.CompleteAsync();

                return new LivrosResponse(livro);
            }
            catch (Exception ex)
            {
                return new LivrosResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<LivrosResponse> UpdateLivro(int id, Livros livro)
        {
            var exibirLivro = await _livrosRepository.GetLivroById(id);

            if (exibirLivro == null)
                return new LivrosResponse("Book not found.");

            exibirLivro.Titulo = livro.Titulo;
            exibirLivro.MinhaResenha = livro.MinhaResenha;
            exibirLivro.Autor = livro.Autor;
            exibirLivro.Editora = livro.Editora;
            exibirLivro.Paginas = livro.Paginas;
            exibirLivro.Lido = livro.Lido;

            try
            {
                _livrosRepository.UpdateLivro(exibirLivro);
                await _unitOfWork.CompleteAsync();

                return new LivrosResponse(exibirLivro);
            }
            catch (Exception ex)
            {
                return new LivrosResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<LivrosResponse> Delete(int id)
        {
            var existingCategory = await _livrosRepository.GetLivroById(id);

            if (existingCategory == null)
                return new LivrosResponse("book not found.");

            try
            {
                _livrosRepository.Delete(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new LivrosResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new LivrosResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
