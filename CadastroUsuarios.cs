using System;
using Microsoft.Data.Sqlite;

namespace GerenciadorEstoque
{
    public class CadastroUsuarios
    {
        public void CadastrarUsuario(string nome, string perfil, string senha)
        {
            string connectionString = "Data Source=estoque.db;Version=3;";
            using (var connection = new SqliteConnection(connectionString))
            {

                connection.Open();
                string usuario = "INSERT INTO Usuarios (Nome, Perfil, Senha) VALUES (@Nome, @Perfil, @Senha)";
                using (var cmd = new SqliteCommand(usuario, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Perfil", perfil);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool AutenticarUsuario(string nome, string senha, out string perfil)
        {
            string connectionString = "Data Source=estoque.db;Version=3;";
            using (var connection = new SqliteConnection(connectionString))
            {

                connection.Open();
                string autenticar = "SELECT Perfil FROM Usuarios WHERE Nome = @Nome AND Senha = @Senha";
                using (var cmd = new SqliteCommand(autenticar, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = reader["Perfil"].ToString();
                            return true;
                        }
                        else
                        {
                            perfil = null;
                            return false;
                        }

                    }
                }
            }
        }
    }
}