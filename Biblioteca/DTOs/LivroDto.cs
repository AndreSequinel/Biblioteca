namespace Biblioteca.DTOs;

public class LivroRequestDto
{
    public string Titulo { get; set; } = string.Empty;
    public int AnoDeLancamento { get; set; }
    public string Editora { get; set; } = string.Empty;
}

public class LivroResponseDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int AnoDeLancamento { get; set; }
    public string Editora { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
}
