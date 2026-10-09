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
    public partial class pagLogin : Form
    {
        private int idUsuario = 0;

        public pagLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            pagCadastroUsuario novaPag = new pagCadastroUsuario();
            novaPag.Show();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //Enter também serve como botão de login
            {
                Logar();
            }
        }

        private void Logar()
        {
            ///Anti-Burro
            if (
                !int.TryParse(txtUsuario.Text, out int idUsuario) ||
                !txtSenha.MaskCompleted
               )
            {
                MessageBox.Show("Ainda há campos faltando!");
                return;
            }

            //procura no banco se o usuário existe
            MySqlDataReader leitor = BancoDeDados.Consultar(
                "SELECT * FROM usuarios WHERE id = @id",
                consulta => { consulta.Parameters.AddWithValue("@id", idUsuario); }
                );

            if (leitor.Read())
            {
                string senhaBanco = leitor["senha"].ToString();

                if (Seguranca.ConferirSenha(txtSenha.Text, senhaBanco)) //Se a senha está correta, então entra no aplicativo
                {
                    MessageBox.Show("Login realizado!");

                    pagCentral novaPag = new pagCentral(idUsuario);
                    novaPag.Show();
                    this.Hide(); //Apenas esconder e não fechar, porque esta é a primeira página, fechá-la significa fechar o app inteiro.
                }
                else //Se não, então não entra
                {
                    MessageBox.Show("Senha incorreta!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado!\nCadastre-se!");
                return;
            }
        }

        private void pagLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtSenha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
