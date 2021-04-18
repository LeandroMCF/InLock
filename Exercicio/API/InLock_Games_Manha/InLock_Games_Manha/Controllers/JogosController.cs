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

        
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> jogos = _jogosRepository.Listar();

            return Ok(jogos);
        }
    }
}
