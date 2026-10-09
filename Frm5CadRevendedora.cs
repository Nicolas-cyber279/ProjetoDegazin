using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public partial class pagCadastroRevendedora : Form
    {
        private int idUsuario;
        public pagCadastroRevendedora()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            //Garante que o usuário não deixou campos em branco
            if (txtNome.Text == "" ||
                txtEmail.Text == "" ||
                txtEndereco.Text == "" ||
                !txtCpf.MaskCompleted)
            {
                MessageBox.Show("Ainda há campos faltosos!");
                return;
            }

            //Valida o E-mail
            if (!Seguranca.EmailValido(txtEmail.Text))
            {
                MessageBox.Show("E-mail inválido!");
                return;
            }

            string email = txtEmail.Text;

            //Confere, com base no cpf, se o cpf digitado já está no banco de dados
            string cpf = txtCpf.Text;

            MySqlDataReader cpfJaExiste = BancoDeDados.Consultar(
                "SELECT * FROM revendedores WHERE cpf = @cpf", 
                parametro => {parametro.Parameters.AddWithValue("@cpf", cpf);}
                );

            if (cpfJaExiste.Read())
            {
                    MessageBox.Show("Revendedora já cadastrada!");
                    return;
            }

            //Cadastra a revendedora
            try
            {
                string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pastaPlanilhas = Path.Combine(pastaDocumentos, "Degazin", "DOCUMENTOS");

                Utilitarios.Imprimir(Path.Combine(pastaPlanilhas, "Contrato de consignação DENISEGAZIN.pdf"));
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro com a impressão silenciosa.", $"Erro: {erro}");
            }

            DialogResult Confirmar = MessageBox.Show($"{txtNome.Text.ToUpper()} assinou o contrato?", "Confirmação", MessageBoxButtons.YesNo);

                if (Confirmar == DialogResult.Yes)
                {
                    var revendedora = BancoDeDados.Inserir(
                   "INSERT INTO revendedores(nome, cpf, email, endereco) VALUES (@nome, @cpf, @email, @endereco)",
                   parametros =>
                   {
                       parametros.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                       parametros.Parameters.AddWithValue("@cpf", cpf);
                       parametros.Parameters.AddWithValue("@email", email);
                       parametros.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                   }
                   );

                    if (revendedora.numeroLinhas > 0)
                    {
                        MessageBox.Show($"Revendedora cadastrada com sucesso!\n{txtNome.Text}, Seja bem-vindo(a) ao time!");
                        lblResultado.Text = $"Sua identificação de revendedora é {revendedora.ultimoId}";

                        try
                        {
                            Utilitarios.EnviarEmail(email, $"{txtNome.Text}, Seu cadastro como um(a) revendedor(a) Denise Gazin semijoias foi concluído! Seja Bem-vindo(a) ao time! 💎");
                        }

                        catch
                        {
                            MessageBox.Show("Erro ao enviar email.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro inexperado!");
                        return;
                    }
                }

                else
                {
                    MessageBox.Show("Que pena! Cadastro cancelado.");
                    return;
                }
        }
    }
}
