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

    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> jogos = _jogosRepository.Listar();

            if (jogos == null)
            {
                return NotFound("Não há jogos disponiveis");
            }

            return Ok(jogos);
        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            JogosDomain jogos = _jogosRepository.BuscarPorId(id);

            if (jogos == null)
            {
                return NotFound("Nenhum jogo foi encontrado");
            }

            return Ok(jogos);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(JogosDomain novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _jogosRepository.Deletar(id);

            return StatusCode(201);
        }
    }
}