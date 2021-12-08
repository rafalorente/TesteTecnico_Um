using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico_Um.Data;
using TesteTecnico_Um.Data.Dtos;
using TesteTecnico_Um.Data.Dtos.Caminhao;
using TesteTecnico_Um.Models;

namespace TesteTecnico_Um.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CaminhaoController : ControllerBase
    {
        private static AppDbContext _context;
        private static IMapper _mapper;

        public CaminhaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCaminhao([FromBody] CreateCaminhaoDto caminhaoDto)
        {
            Caminhao caminhao = _mapper.Map<Caminhao>(caminhaoDto);
            _context.Caminhao.Add(caminhao);
            _context.SaveChanges();

            //Retorna dentro do Headers o location exato para consultar o dado
            return CreatedAtAction(nameof(RecuperaCaminhaoPorId), new { Id = caminhao.IdCaminhao }, caminhao);
        }

        //Recupera todos os caminhoes
        [HttpGet]
        public IEnumerable<Caminhao> RecuperaCaminhao()
        {
            return _context.Caminhao;
        }

        //Recupera todos os caminhoes por Id
        [HttpGet("{id}")]
        public IActionResult RecuperaCaminhaoPorId(int id)
        {
            Caminhao caminhao = _context.Caminhao.FirstOrDefault(caminhao => caminhao.IdCaminhao == id);

            if (caminhao != null)
            {
                ReadCaminhaoDto caminhaoDto = _mapper.Map<ReadCaminhaoDto>(caminhao);
                return Ok(caminhao);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCaminhao(int id, [FromBody] UpdateCaminhaoDto caminhaoDto)
        {
            Caminhao caminhao = _context.Caminhao.FirstOrDefault(caminhao => caminhao.IdCaminhao == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            _mapper.Map(caminhaoDto, caminhao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCaminhao(int id)
        {
            Caminhao caminhao = _context.Caminhao.FirstOrDefault(caminhao => caminhao.IdCaminhao == id);

            if (caminhao == null)
            {
                return NotFound();
            }
            
            _context.Remove(caminhao);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
