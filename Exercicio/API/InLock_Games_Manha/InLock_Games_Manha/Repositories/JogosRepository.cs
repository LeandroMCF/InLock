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
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string buscandoId = "SELECT Estudios.NomeEstudios, Jogos.NomeJogos, Jogos.Valor, CONVERT(VARCHAR(10), DataLancamento,3) FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudios = Estudios.IdEstudios WHERE IdJogos =" + id;

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(buscandoId, con))
                {
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain()
                        {
                            estudios = new EstudiosDomain()
                            {
                                NomeEstudios = rdr[0].ToString()
                            },

                            NomeJogos = rdr[1].ToString(),
                            valor = Convert.ToDouble(rdr[2]),
                            DataLancamento = rdr[3].ToString()
                        };

                        return jogos;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string cadastrar = "INSERT INTO Jogos (IdEstudios, NomeJogos, Descricao, DataLancamento, Valor)" +
                    "VALUES (" + novoJogo.IdEstudios + ", '" + novoJogo.NomeJogos + "', '" + novoJogo.Descricao + "', '" + novoJogo.DataLancamento + "', " + novoJogo.valor + ")";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(cadastrar, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string excluindo = "DELETE FROM Jogos WHERE IdJogos =" + id;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(excluindo, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> listaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySellectAll = "SELECT Jogos.IdEstudios, Jogos.NomeJogos, Jogos.Valor, CONVERT(VARCHAR(10), DataLancamento,3), Estudios.NomeEstudios FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudios = Estudios.IdEstudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySellectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain()
                        {
                            estudios = new EstudiosDomain()
                            {
                                NomeEstudios = rdr[4].ToString(),
                            },

                            IdEstudios = rdr[0].ToString(),
                            NomeJogos = rdr[1].ToString(),
                            valor = Convert.ToInt32(rdr[2]),
                            DataLancamento = rdr[3].ToString(),

                        };

                        listaJogos.Add(jogos);
                    }
                }
            }

            return listaJogos;
        }
    }
}