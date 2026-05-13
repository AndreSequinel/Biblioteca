using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly AppDbContext _appDbContext;

    public LivroRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Livro> CriarAsync(Livro livro)
    {
        _appDbContext.Livros.Add(livro);
        await _appDbContext.SaveChangesAsync();
        return livro;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var livro = await _appDbContext.Livros.FindAsync(id);

        if (livro == null) return false;

        _appDbContext.Remove(livro);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Livro>> ObterTodosAsync()
    {
        return await _appDbContext.Livros.ToListAsync();
    }

    public async Task<Livro?> ObterPorIdAsync(int id)
    {
        return await _appDbContext.Livros.FindAsync(id);
    }

    public async Task<Livro?> AtualizarAsync(int id, Livro livro)
    {
        var livroExiste = await _appDbContext.Livros.FindAsync(id);
        if (livroExiste is null) return null;

        livroExiste.Titulo = livro.Titulo;
        livroExiste.AnoDeLancamento = livro.AnoDeLancamento;
        livroExiste.Editora = livro.Editora;

        await _appDbContext.SaveChangesAsync();
        return livroExiste;
    }
}
