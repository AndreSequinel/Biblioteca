using Biblioteca.DTOs;
using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        this.livroRepository = livroRepository;
    }
    public async Task<IEnumerable<LivroResponseDto>> ObterTodosAsync()
    {
        var livros = await livroRepository.ObterTodosAsync();
        return livros.Select(ParaDto);
    }

    public async Task<LivroResponseDto?> AtualizarAsync(int id, LivroRequestDto dto)
    {
        var livro = new Livro
        {
            Titulo = dto.Titulo,
            AnoDeLancamento = dto.AnoDeLancamento,
            Editora = dto.Editora
        };

        var livroAtualizado = await livroRepository.AtualizarAsync(id, livro);
        return livroAtualizado is null ? null : ParaDto(livroAtualizado);
    }

    public async Task<LivroResponseDto> CriarAsync(LivroRequestDto dto)
    {
        var livro = new Livro
        {
            Titulo = dto.Titulo,
            AnoDeLancamento = dto.AnoDeLancamento,
            Editora = dto.Editora
        };

        var livroCriado = await livroRepository.CriarAsync(livro);
        return ParaDto(livroCriado);
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var livroDeletado = await livroRepository.DeletarAsync(id);
        return livroDeletado;
    }

    public async Task<LivroResponseDto?> ObterPorIdAsync(int id)
    {
        var livro = await livroRepository.ObterPorIdAsync(id);
        return livro is null ? null : ParaDto(livro);
    }

    // Mapeamento manual Model -> DTO
    private static LivroResponseDto ParaDto(Livro livro) => new()
    {
        Id = livro.Id,
        Titulo = livro.Titulo,
        AnoDeLancamento = livro.AnoDeLancamento,
        Editora = livro.Editora,
        CriadoEm = livro.CriadoEm
    };

}
