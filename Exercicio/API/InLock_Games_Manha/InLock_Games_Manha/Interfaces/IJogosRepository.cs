using InLock_Games_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Interfaces
{
    interface IJogosRepository
    {
        List<JogosDomain> Listar();

        void Cadastrar(JogosDomain novoJogo);

        void Deletar(int id);

        JogosDomain BuscarPorId(int id);
    }
}
