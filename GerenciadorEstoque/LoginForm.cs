using Microsoft.Data.Sqlite;

namespace GerenciadorPedidos
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private ComboBox cmbPerfil;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
            cmbPerfil.Items.AddRange(new[] { "Admin", "Vendedor" });
            new DatabaseHelper().InitializeDatabase();
        }

        private void InitializeComponent()
        {
            this.txtUsuario = new TextBox();
            this.txtSenha = new TextBox();
            this.cmbPerfil = new ComboBox();
            this.btnLogin = new Button();
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            // Adicione os controles ao formulário e defina suas propriedades
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            string perfil = cmbPerfil.SelectedItem?.ToString();

            using (var conn = new SQLiteConnection("Data Source=estoque.db;Version=3;"))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Usuarios WHERE Nome=@nome AND Senha=@senha AND Perfil=@perfil";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.Parameters.AddWithValue("@perfil", perfil);

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    if (perfil == "Admin") new AdminForm().Show();
                    else new VendedorForm().Show();
                    this.Hide();
                }
                else MessageBox.Show("Credenciais inválidas!");
            }
        }
    }
}
