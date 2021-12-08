using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico_Um.Data;
using TesteTecnico_Um.Data.Dtos.Endereco;
using TesteTecnico_Um.Models;

namespace TesteTecnico_Um.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private static AppDbContext _context;
        private static IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();

            //Retorna dentro do Headers o location exato para consultar o dado
            return CreatedAtAction(nameof(RecuperaCaminhaoPorId), new { Id = endereco.IdEndereco }, endereco);
        }

        //Recupera todos os Enderecos
        [HttpGet]
        public IEnumerable<Endereco> RecuperaEnderecoo()
        {
            return _context.Endereco;
        }

        //Recupera todos os Enderecos por Id
        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.IdEndereco == id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(endereco);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.IdEndereco == id);
            if (endereco == null)
            {
                return NotFound();
            }

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.IdEndereco == id);

            if (endereco == null)
            {
                return NotFound();
            }

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
