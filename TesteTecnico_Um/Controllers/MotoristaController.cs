using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico_Um.Data;
using TesteTecnico_Um.Data.Dtos;
using TesteTecnico_Um.Models;

namespace TesteTecnico_Um.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MotoristaController : ControllerBase
    {
        private static AppDbContext _context;
        private static IMapper _mapper;

        public MotoristaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaMotorista([FromBody] CreateMotoristaDto motoristaDto)
        {
            Motorista motorista = _mapper.Map<Motorista>(motoristaDto);
            _context.Motorista.Add(motorista);
            _context.SaveChanges();

            //Retorna dentro do Headers o location exato para consultar o dado
            return CreatedAtAction(nameof(RecuperaMotoristaPorId), new { Id = motorista.IdMotorista }, motorista);
        }

        //Recupera todos os motoristas
        [HttpGet]
        public IEnumerable<Motorista> RecuperaMotorista()
        {
            return _context.Motorista;
        }

        //Recupera todos os motoristas por Id
        [HttpGet("{id}")]
        public IActionResult RecuperaMotoristaPorId(int id)
        {
            Motorista motorista = _context.Motorista.FirstOrDefault(motorista => motorista.IdMotorista == id);

            if (motorista != null)
            {
                ReadMotoristaDto motoristaDto = _mapper.Map<ReadMotoristaDto>(motorista);
                return Ok(motorista);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaMotorista(int id, [FromBody] UpdateMotoristaDto motoristaDto)
        {
            Motorista motorista = _context.Motorista.FirstOrDefault(motorista => motorista.IdMotorista == id);
            if (motorista == null)
            {
                return NotFound();
            }

            _mapper.Map(motoristaDto, motorista);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaMotorista(int id)
        {
            Motorista motorista = _context.Motorista.FirstOrDefault(motorista => motorista.IdMotorista == id);

            if (motorista == null)
            {
                return NotFound();
            }
            
            _context.Remove(motorista);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
