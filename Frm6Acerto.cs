using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public partial class pagAcerto : Form
    {
        int idPagador;
        List<int> IDs = new List<int>();
        public pagAcerto()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ///Anti-Burro
            if (cbbRevendedores.Text == "Selecione um revendedor" ||
                !decimal.TryParse(txtValorPagamento.Text, out decimal valorPago) ||
                dtDataPagamento.Value == new DateTime(1753, 1, 1) ||
                txtFormaPagamento.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }
            
            ///Salva no banco
            int indice = cbbRevendedores.SelectedIndex;
            idPagador = IDs[indice];
            DateTime dataPagamento = dtDataPagamento.Value;
            string formaPagamento = txtFormaPagamento.Text.ToUpper();

            var acerto = BancoDeDados.Inserir(
                "INSERT INTO acertos(revendedores_id, valor_pago, data_pagamento, forma_pagamento) VALUES (@id, @valor, @data, @forma)",
                sql =>
                {
                    sql.Parameters.AddWithValue("@id", idPagador);
                    sql.Parameters.AddWithValue("@valor", valorPago);
                    sql.Parameters.AddWithValue("@data", dataPagamento);
                    sql.Parameters.AddWithValue("@forma", formaPagamento);
                }
                );

            var DesligarSeguranca = BancoDeDados.Executar("SET SQL_SAFE_UPDATES = 0");
            var acertarSaldo = BancoDeDados.Executar("UPDATE revendedores SET saldo = saldo + @acerto WHERE id = @id",
                sql =>
                {
                    sql.Parameters.AddWithValue("@id", idPagador);
                    sql.Parameters.AddWithValue("@acerto", valorPago);
                }
                );
            var LigarSeguranca = BancoDeDados.Executar("SET SQL_SAFE_UPDATES = 1");

            if(acerto.numeroLinhas > 0)
            {
                if(MessageBox.Show("Acerto realizado com sucesso!", "Acertar novamente?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cbbRevendedores.Text = "Selecione um revendedor";
                    txtValorPagamento.Text = "";
                    dtDataPagamento.Value = new DateTime(1753, 1, 1);
                    txtFormaPagamento.Text = "";
                }
                else
                {
                    MessageBox.Show("Fechando!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Erro inesperado!");
                return;
            }
        }

        private void pagAcerto_Load(object sender, EventArgs e)
        {
            //Seleciona todos os vendedores com listas de índices sincronizados
            var vendedores = BancoDeDados.Consultar("SELECT * FROM revendedores ORDER BY nome");
            while (vendedores.Read())
            {
                cbbRevendedores.Items.Add(vendedores["nome"].ToString());
                IDs.Add(Convert.ToInt32(vendedores["id"]));
            }

        }
    }
}
