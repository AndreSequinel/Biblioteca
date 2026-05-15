using Biblioteca.DTOs;

namespace Biblioteca.Services;

public interface ILivroService
{
    Task<LivroResponseDto?> ObterPorIdAsync(int id);
    Task<LivroResponseDto?> AtualizarAsync(int id, LivroRequestDto dto);
    Task<IEnumerable<LivroResponseDto>> ObterTodosAsync();
    Task<List<LivroResponseDto>> CriarAsync(List<LivroRequestDto> dto);
    Task<bool> DeletarAsync(int id);
}