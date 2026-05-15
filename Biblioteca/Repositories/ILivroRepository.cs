using Biblioteca.Models;

namespace Biblioteca.Repositories;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> ObterTodosAsync();
    Task<Livro?> ObterPorIdAsync(int id);
    Task<List<Livro>> CriarAsync(List<Livro> livro);
    Task<Livro?> AtualizarAsync(int id, Livro livro);
    Task<bool> DeletarAsync(int id);
}
