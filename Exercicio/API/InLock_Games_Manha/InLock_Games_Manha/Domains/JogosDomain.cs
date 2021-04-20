using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Domains
{
    public class JogosDomain
    {
        public int IdJogos { get; set; }
        public string IdEstudios { get; set; }
        public string NomeJogos { get; set; }
        public string Descricao { get; set; }
        public string DataLancamento { get; set; }
        public decimal valor { get; set; }
        public EstudiosDomain estudios { get; set; }
    }
}
