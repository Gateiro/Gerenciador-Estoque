using System;

namespace GerenciadorPedidos.controller
{
    public class Usuario
    {
        public int Id
        {
            get; set;
        }
        public string Nome
        {
            get; set;
        }
        public string Perfil
        {
            get; set;
        }
        public string Senha
        {
            get; set;
        }

        public Usuario(int id, string nome, string perfil, string senha)
        {
            Id = id;
            Nome = nome;
            Perfil = perfil;
            Senha = senha;
        }

        public static Usuario CriarNovoUsuario(string nome, string perfil, string senha)
        {
            return new Usuario(0, nome, perfil, senha); // O ID será gerado automaticamente pelo banco de dados
        }

    }
}

