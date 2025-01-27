﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestePraticoPloomes.Extensions;
using TestePraticoPloomes.IServices;
using TestePraticoPloomes.Models;
using TestePraticoPloomes.Resources;

namespace TestePraticoPloomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private ILivrosService _livroService;
        private readonly IMapper _mapper;

        public LivrosController(ILivrosService livrosService, IMapper mapper)
        {
            _livroService = livrosService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LivrosResource>> GetLivros()
        {
            var livros = await _livroService.GetBaseLivros();
            var recursos = _mapper.Map<IEnumerable<Livros>, IEnumerable<LivrosResource>>(livros);
            return recursos;
        }

        [HttpGet("{id:int}", Name = "GetLivroById")]
        public async Task<ActionResult<LivrosResource>> GetLivroById(int id)
        {

            try
            {
                var livro = await _livroService.GetLivroById(id);
                var recurso = _mapper.Map<Livros, LivrosResource>(livro);

                if (livro == null)
                {
                    return NotFound("Livro não encontrado");
                }

                return recurso;
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLivrosResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var livro = _mapper.Map<SaveLivrosResource, Livros>(resource);
            var result = await _livroService.AddLivro(livro);

            if (!result.Success)
                return BadRequest(result.Message);

            var livroResource = _mapper.Map<Livros, LivrosResource>(result.Livros);
            return Ok(livroResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLivrosResource recurso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var livro = _mapper.Map<SaveLivrosResource, Livros>(recurso);
            var result = await _livroService.UpdateLivro(id, livro);

            if (!result.Success)
                return BadRequest(result.Message);

            var livroResource = _mapper.Map<Livros, LivrosResource>(result.Livros);
            return Ok(livroResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _livroService.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var livroResource = _mapper.Map<Livros, LivrosResource>(result.Livros);
            return Ok(livroResource);
        }
    }
}
