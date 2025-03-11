using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace GerenciadorPedidos.controller
{

    public partial class VendedorForm : Form
    {
        private readonly string connectionString = "Data Source=estoque.db;Version=3;";
        private ComboBox cmbProduto;
        private TextBox txtQuantidade;
        private TextBox txtCPF;
        private TextBox txtCliente;
        private Button btnVender;

        public VendedorForm()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void InitializeComponent()
        {
            cmbProduto = new ComboBox();
            txtQuantidade = new TextBox();
            txtCPF = new TextBox();
            txtCliente = new TextBox();
            btnVender = new Button();
            btnVender.Click += new EventHandler(btnVender_Click);

        }

        private void CarregarProdutos()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Produtos";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbProduto.DataSource = dt;
                        cmbProduto.DisplayMember = "Nome";
                        cmbProduto.ValueMember = "Id";
                    }
                }
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Atualiza estoque
                        string updateSql = "UPDATE Produtos SET Quantidade = Quantidade - @qtd WHERE Id = @id";
                        using (var updateCmd = new SqliteCommand(updateSql, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@qtd", int.Parse(txtQuantidade.Text));
                            updateCmd.Parameters.AddWithValue("@id", cmbProduto.SelectedValue);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Registra venda
                        string insertSql = @"INSERT INTO Pedidos (ClienteCPF, ClienteNome, ProdutoId, QuantidadeVendida, Valor) 
                                                            VALUES (@cpf, @nome, @prodId, @qtd, @valor)";
                        using (var insertCmd = new SqliteCommand(insertSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
                            insertCmd.Parameters.AddWithValue("@nome", txtCliente.Text);
                            insertCmd.Parameters.AddWithValue("@prodId", cmbProduto.SelectedValue);
                            insertCmd.Parameters.AddWithValue("@qtd", int.Parse(txtQuantidade.Text));
                            insertCmd.Parameters.AddWithValue("@valor", decimal.Parse(txtQuantidade.Text) *
                                Convert.ToDecimal(((DataRowView)cmbProduto.SelectedItem)["Preco"]));
                            insertCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Venda registrada!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }
        }
    }
}
