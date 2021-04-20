using InLock_Games_Manha.Domains;
using InLock_Games_Manha.Interfaces;
using InLock_Games_Manha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository;

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<EstudiosDomain> estudios = _estudiosRepository.Listar();

            if (estudios == null)
            {
                return NotFound("Nenhum  estudio encontrado");
            }

            return Ok(estudios);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(EstudiosDomain novoEstudio)
        {
            _estudiosRepository.Cadastrar(novoEstudio);

            return StatusCode(202);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _estudiosRepository.Deletar(id);

            return StatusCode(202);
        }

    }
}
