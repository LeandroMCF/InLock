using InLock_Games_Manha.Domains;
using InLock_Games_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=InLock_Games_Manha; integrated security=true";
        public UsuariosDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string logando = "SELECT IdUsuarios, Email, Senha, TipoUsuarios.Titulo " +
                                 "FROM Usuarios " +
                                 "INNER JOIN TipoUsuarios " +
                                 "ON Usuarios.IdTipoUsuario = TipoUsuarios.IdTipoUsuarios " +
                                 "WHERE Email = '" + email + "' AND Senha = '" + senha + "'";

                using (SqlCommand cmd = new SqlCommand(logando, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuario = new UsuariosDomain
                        {
                            IdUsuarios = Convert.ToInt32(rdr["IdUsuarios"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = rdr["Titulo"].ToString()
                        };

                        return usuario;
                    }

                    return null;
                }
            }
        }
    }
}
