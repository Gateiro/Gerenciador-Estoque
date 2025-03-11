using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace GerenciadorPedidos.controller
{
    public class Administrador : Usuario
    {
        public Administrador(int id, string nome, string senha)
            : base(id, nome, "Admin", senha)
        {
        }

        public AdminForm()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            using (var conn = new SQLiteConnection("Data Source=estoque.db;Version=3;"))
            {
                conn.Open();
                string sql = "SELECT * FROM Produtos";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProdutos.DataSource = dt;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection("Data Source=estoque.db;Version=3;"))
            {
                conn.Open();
                string sql = "INSERT INTO Produtos (Nome, Codigo, Preco, Quantidade) VALUES (@nome, @codigo, @preco, @quantidade)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
                cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text));
                cmd.ExecuteNonQuery();
                CarregarProdutos();
            }
        }
    }
}
}
