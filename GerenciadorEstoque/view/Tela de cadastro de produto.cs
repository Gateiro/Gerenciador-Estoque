using System;
using System.Windows.Forms;

namespace GerenciadorPedidos.view
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Captura os valores digitados
            string nome = txtNome.Text;
            string codigo = txtCodigo.Text;
            string preco = txtPreco.Text;
            string quantidade = txtQuantidade.Text;

            // Verifica se os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(preco) || string.IsNullOrWhiteSpace(quantidade))
            {
                MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe mensagem de confirmação
            MessageBox.Show($"Produto '{nome}' cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpa os campos após o cadastro
            txtNome.Clear();
            txtCodigo.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
        }
    }
}
