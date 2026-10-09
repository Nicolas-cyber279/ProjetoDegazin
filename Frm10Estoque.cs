using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public partial class pagListaEstoque : Form
    {
        public pagListaEstoque()
        {
            InitializeComponent();
        }

        private void pagListaEstoque_Load(object sender, EventArgs e)
        {
            MySqlDataReader leitorPecas = BancoDeDados.Consultar("SELECT * FROM estoque");
            while (leitorPecas.Read())
            {
                string dg = leitorPecas["id_degazin"].ToString();
                string codigo = leitorPecas["codigo_original"].ToString();
                string descricao = leitorPecas["descricao"].ToString();
                string preco = Convert.ToDecimal(leitorPecas["preco"]).ToString("C");
                string vendida = (leitorPecas["data_saida"] == DBNull.Value) ? "NÃO":"SIM";

                dtGridTabela.Rows.Add(dg, codigo, descricao, preco, vendida);

            }
        }

        private void dtGridTabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void pesquisar()
        {
            string pesquisa = txtPesquisa.Text.Trim();

            if (string.IsNullOrEmpty(pesquisa))
            {
                MessageBox.Show("Digite um código DG ou código original.");
                return;
            }

            bool encontrado = false;

            foreach (DataGridViewRow linha in dtGridTabela.Rows)
            {
                if (linha.IsNewRow)
                    continue;

                string dg = linha.Cells["ColDG"].Value?.ToString();
                string codigoOriginal = linha.Cells["ColCodigo"].Value?.ToString();

                if (dg == pesquisa || codigoOriginal == pesquisa)
                {
                    dtGridTabela.ClearSelection();
                    linha.Selected = true;

                    dtGridTabela.FirstDisplayedScrollingRowIndex = linha.Index;

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                MessageBox.Show("Nenhuma peça encontrada.");
            }

            txtPesquisa.Text = "";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                pesquisar();
            }
        }
    }
}
