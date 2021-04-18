using InLock_Games_Manha.Domains;
using InLock_Games_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=InLock_Games_Manha; integrated security=true";

        public JogosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> listaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySellectAll = "SELECT Estudios.NomeEstudio, NomeJogos, Valor, CONVERT(VARCHAR(10), DataLancamento,3)" +
                                         "From Jogos" +
                                         "INNER JOIN Estudios" +
                                         "ON Jogos.IdEstudios = Estudios.IdEstudios";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySellectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain()
                        {
                            IdEstudios = rdr[0].ToString(),
                            NomeJogos = rdr[1].ToString(),
                            valor = Convert.ToDouble(rdr[2]),
                            DataLancamento = rdr[3].ToString()
                        };

                        listaJogos.Add(jogos);
                    }
                }
            }

            return listaJogos;
        }
    }
}