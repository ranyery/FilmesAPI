using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/filmes")]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Adiciona([FromBody] CreateFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterFilmePeloId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult ObterListaFilmes()
        {
            var filmes = _context.Filmes;
            return Ok(filmes);
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterFilmePeloId([FromRoute] int id)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filmeEncontrado == null) return NotFound();

            return Ok(filmeEncontrado);
        }

        [HttpPut("{id:int}")]
        public IActionResult AtualizaFilme([FromRoute] int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletaFilme([FromRoute] int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
