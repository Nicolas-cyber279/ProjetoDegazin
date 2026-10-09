using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public partial class pagEstoque : Form
    {
        public pagEstoque()
        {
            InitializeComponent();
        }

        private void pagEstoque_Load(object sender, EventArgs e)
        {
            lblCodigoDg.Text = "";
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            Cadastro();
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Cadastro();
                txtCodigo.Focus();
                txtCodigo.SelectionStart = 0;
            }
        }

        private async Task Cadastro()
        {
            ///Anti-Burro
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                MessageBox.Show("O campo 'Código original' deve ser preenchido com um número inteiro!");
                return;
            }
            if (codigo <= 0)
            {
                MessageBox.Show("O campo 'Codigo' deve ser preenchido com um número positivo!");
                return;
            }
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("O campo 'Descrição' não pode estar vazio!");
                return;
            }
            if (!decimal.TryParse(txtPreco.Text, out decimal preco))
            {
                MessageBox.Show("O campo 'Preço' deve ser preenchido com um número decimal!");
                return;
            }
            if(preco <= 0)
            {
                MessageBox.Show("O campo 'Preço' deve ser preenchido com um número positivo!");
                return;
            }

            string descricao = txtDescricao.Text;
            DateTime dataEntrada = DateTime.Today;

            //Cadastra a peça no estoque
            try
            {
                var cadastroPeca = BancoDeDados.Inserir(
                    "INSERT INTO estoque(codigo_original, descricao, preco, data_entrada) VALUES (@codigo, @desc, @preco, @data)",
                    parametros =>
                    {
                        parametros.Parameters.AddWithValue("@codigo", codigo);
                        parametros.Parameters.AddWithValue("@desc", descricao);
                        parametros.Parameters.AddWithValue("@preco", preco);
                        parametros.Parameters.AddWithValue("@data", dataEntrada);
                    }
                    );

                if (cadastroPeca.numeroLinhas > 0)
                {
                    MessageBox.Show($"Peça Cadastrada! o DG dela é: {cadastroPeca.ultimoId}");
                    lblCodigoDg.Text = $"O código DG dessa peça é {cadastroPeca.ultimoId}.";

                    await Task.Delay(500);
                    txtCodigo.Text = "";
                    txtDescricao.Text = "";
                    txtPreco.Text = "";
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show($"Erro inesperado!\nErro: {erro}");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            pagListaEstoque novaPag = new pagListaEstoque();
            novaPag.Show();
        }
    }
}
