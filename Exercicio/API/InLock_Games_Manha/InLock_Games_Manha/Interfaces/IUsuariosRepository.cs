using InLock_Games_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Interfaces
{
    interface IUsuariosRepository
    {
        UsuariosDomain Login(string email, string senha);
    }
}
