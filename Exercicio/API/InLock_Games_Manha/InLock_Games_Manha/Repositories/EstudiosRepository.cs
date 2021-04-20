using InLock_Games_Manha.Domains;
using InLock_Games_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=InLock_Games_Manha; integrated security=true";

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string cadastrando = "INSERT INTO Estudios (NomeEstudios) VALUES ('"+ novoEstudio.NomeEstudios +"')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(cadastrando, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string excluindoJogo = "DELETE FROM Jogos WHERE IdEstudios =" + id;

                string excluindo = "DELETE FROM Estudios WHERE IdEstudios =" + id;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(excluindoJogo, con))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(excluindo, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudiosDomain> Listar()
        {
            List<EstudiosDomain> listaEstudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string listar = "SELECT Estudios.IdEstudios AS ID, Estudios.NomeEstudios AS Estudio, Jogos.NomeJogos FROM Estudios LEFT JOIN Jogos ON Estudios.IdEstudios = Jogos.IdEstudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(listar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain estudios = new EstudiosDomain()
                        {
                            IdEstudios = Convert.ToInt32(rdr[0]),
                            NomeEstudios = rdr[1].ToString(),
                            jogos = new JogosDomain()
                            {
                                NomeJogos = rdr[2].ToString(),
                            },
                        };

                        listaEstudios.Add(estudios);
                    }
                }
            }

            return listaEstudios;
        }
    }
}