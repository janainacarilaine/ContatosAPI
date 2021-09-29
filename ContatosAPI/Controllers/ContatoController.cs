using AutoMapper;
using ContatosAPI.Data;
using ContatosAPI.Data.Dtos;
using ContatosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContatoController : ControllerBase
    {
        private ContatoContexto _context;
        private IMapper _mapper;
        public ContatoController(ContatoContexto contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaContato([FromBody] CriarContatoDto contatoDto)
        {
            Contato contato = _mapper.Map<Contato>(contatoDto);
            
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetContatoPorNome), new {contato.Nome, contato.Id}, contato);
            
        }

        [HttpGet]
        public IActionResult GetContato()
        {
            return Ok(_context.Contatos);
        }

        [HttpGet("{nome}")]
        public IActionResult ObterContatoPorNome(string nome)
        {
            StringComparison name = StringComparison.OrdinalIgnoreCase;

            List<Contato> cont = new ();
            foreach (var contato in _context.Contatos.AsNoTracking())
            {
                if (contato.Nome.StartsWith(nome, name))
                {
                    cont.Add(contato);
                }
            }
            if (cont.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cont);
            }
            
        }

        [HttpPut("{id:int}")]
        public IActionResult AlteraContato(int id,[FromBody] AlteraContatoDto contatoNovoDto)
        {
            Contato contato = _context.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato == null)
            {
                return NotFound();
            }
            _mapper.Map(contatoNovoDto, contato);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletaContato(int id)
        {
            Contato contato = _context.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato == null)
            {
                return NotFound();
            }
            _context.Remove(contato);
            _context.SaveChanges();
            return NoContent();
        }

        
    }
}
