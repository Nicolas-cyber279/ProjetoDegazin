using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public partial class pagCadastroUsuario : Form
    {

        public pagCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            ///Anti-Burro
            if (
                txtNome.Text == "" ||
                !txtCpf.MaskCompleted ||
                !txtSenha.MaskCompleted
                )
            {
                MessageBox.Show("Ainda há campos faltosos!");
                return;
            }

            string cpf = txtCpf.Text;

            //Confere se o usuário já existe pelo cpf
            MySqlDataReader cpfJaExiste = BancoDeDados.Consultar(
                "SELECT * FROM usuarios WHERE cpf = @cpf",
                parametro => { parametro.Parameters.AddWithValue("@cpf", cpf); }
                );

            if (cpfJaExiste.Read())
            {
                MessageBox.Show("Usuário Já Cadastrado!");
                return;
            }
            
            //Cadastra o usuário
            string hash = Seguranca.GerarHash(txtSenha.Text);
            

            var resultado = BancoDeDados.Inserir(
                "INSERT INTO usuarios(nome, senha, cpf) VALUES (@nome, @senha, @cpf)",
                comando => //cria um 'método instantâneo' para substituir o NULL da classe.
                {
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@senha", hash);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                }
                );

            if (resultado.numeroLinhas > 0)
            {
                MessageBox.Show($"Usuário Cadastrado com sucesso!\nAnote seu login: {resultado.ultimoId.ToString()}");
                lblCadastro.Text = $"Seu login é: {resultado.ultimoId.ToString()}";
            }
            else
            {
                MessageBox.Show("Erro inesperado!");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pagCadastroUsuario_Load(object sender, EventArgs e)
        {
            lblCadastro.Text = "";
        }
    }
}
