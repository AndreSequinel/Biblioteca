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
        var livro = await livroRepository.ObterPorIdAsync(id);

        if (livro is null)
            return null;

        if (!string.IsNullOrEmpty(dto.Titulo))
            livro!.Titulo = dto.Titulo;

        if (dto.AnoDeLancamento != null)
            livro!.AnoDeLancamento = dto.AnoDeLancamento;

        if (!string.IsNullOrEmpty(dto.Editora))
            livro!.Editora = dto.Editora;

        var livroAtualizado = await livroRepository.AtualizarAsync(id, livro);
        return livroAtualizado is null ? null : ParaDto(livroAtualizado);
    }

    public async Task<List<LivroResponseDto>> CriarAsync(List<LivroRequestDto> dto)
    {
        var listaLivros = dto.Select(x => new Livro
        {
            Titulo = x.Titulo,
            AnoDeLancamento = x.AnoDeLancamento,
            Editora =  x.Editora
        }).ToList();

        var livroCriado = await livroRepository.CriarAsync(listaLivros);
        return livroCriado.Select(ParaDto).ToList();
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
