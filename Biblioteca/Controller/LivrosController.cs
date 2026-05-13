using Biblioteca.DTOs;
using Biblioteca.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;
        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var livros = await _livroService.ObterTodosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var livro = await _livroService.ObterPorIdAsync(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] LivroRequestDto dto)
        {
            var criado = await _livroService.CriarAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
        }
    }
}
