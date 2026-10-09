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
    public partial class pagCentral : Form
    {
        private int idUsuario;
        public pagCentral(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnCadRevendedora_Click(object sender, EventArgs e)
        {
            pagCadastroRevendedora novaPag = new pagCadastroRevendedora();
            novaPag.Show();
        }

        private void btnAtendimento_Click(object sender, EventArgs e)
        {
            pagAtendimento novaPag = new pagAtendimento(idUsuario);
            novaPag.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            pagEstoque novaPag = new pagEstoque();
            novaPag.Show();
        }

        private void btnAcerto_Click(object sender, EventArgs e)
        {
            pagAcerto novaPag = new pagAcerto();
            novaPag.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            pagLogin novaPag = new pagLogin();
            novaPag.Show();
            this.Close();
        }
    }
}
