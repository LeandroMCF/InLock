using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Domains
{
    public class EstudiosDomain
    {
        public JogosDomain jogos { get; set; }
        public int IdEstudios { get; set; }
        public string NomeEstudios { get; set; }
    }
}
