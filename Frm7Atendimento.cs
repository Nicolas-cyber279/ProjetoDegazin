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
    public partial class pagAtendimento : Form
    {
        private int idUsuario;
        public pagAtendimento(int IDUsuario)
        {
            InitializeComponent();
            this.idUsuario = IDUsuario;
        }

        private void pagAtendimento_Load(object sender, EventArgs e)
        {
        }

        private void btnDarBaixa_Click(object sender, EventArgs e)
        {
            ///Anti-Burro
            if (txtIdVendedor.Text == "")
            {
                MessageBox.Show("Digite o ID de quem você vai atender!");
                return;
            }

            if (!int.TryParse(txtIdVendedor.Text, out int idVendedor))
            {
                MessageBox.Show("Digite um ID válido: um número inteiro positivo!");
                return;
            }
            if (idVendedor <= 0)
            {
                MessageBox.Show("Digite um ID válido: um número inteiro POSITIVO!");
                return;
            }

            MySqlDataReader conferirID = BancoDeDados.Consultar(
                "SELECT * FROM revendedores WHERE id = @id",
                parametros => { parametros.Parameters.AddWithValue("@id", idVendedor); }
                );

            if (!conferirID.Read())
            {
                MessageBox.Show("Revendedor inexistente!");
                return;
            }
            else //Abre a página de dar baixa em Janela
            {
                pagDarBaixa novaPag = new pagDarBaixa(idUsuario, idVendedor);
                novaPag.Show();
            }

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            ///Anti-Burro
            if (txtIdVendedor.Text == "")
            {
                MessageBox.Show("Digite o ID de quem você vai atender!");
                return;
            }

            if (!int.TryParse(txtIdVendedor.Text, out int idVendedor))
            {
                MessageBox.Show("Digite um ID válido: um número inteiro positivo!");
                return;
            }
            if (idVendedor <= 0)
            {
                MessageBox.Show("Digite um ID válido: um número inteiro POSITIVO!");
                return;
            }

            MySqlDataReader conferirID = BancoDeDados.Consultar(
                "SELECT * FROM revendedores WHERE id = @id",
                parametros => { parametros.Parameters.AddWithValue("@id", idVendedor); }
                );
            if (!conferirID.Read())
            {
                MessageBox.Show("Revendedora inexistente!");
                return;
            }
            else //Abre a página de Registro de peça pra Revendedora em janela
            {
                pagRegistroRev novaPag = new pagRegistroRev(idUsuario, idVendedor);
                novaPag.Show();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            pagCentral novaPag = new pagCentral(idUsuario);
            novaPag.Show();
            this.Close();
        }
    }
}
