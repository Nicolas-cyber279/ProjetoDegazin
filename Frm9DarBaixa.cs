using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace ProjetoDegazin
{
    public partial class pagDarBaixa : Form
    {
        private int idUsuario, idVendedor, idAtendimento;
        private string nomeAtendido;
        private List<int> pecasEsperadas = new List<int>(), pecasDevolvidas = new List<int>(), pecasVendidas = new List<int>();

        public pagDarBaixa(int IdUsuario, int IdVendedor)
        {
            InitializeComponent();
            this.idUsuario = IdUsuario;
            this.idVendedor = IdVendedor;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            Devolver();
        }

        private void btnDevolver_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Ajeita o front-end
            lblResultado.Text = "";
            MySqlDataReader leitor = BancoDeDados.Consultar(
                "SELECT * FROM revendedores WHERE id = @id",
                parametros => { parametros.Parameters.AddWithValue("@id", idVendedor); }
                );

            if (leitor.Read())
            {
                nomeAtendido = leitor["nome"].ToString();
                lblTitulo.Text = $"Dar Baixa nas peças de {nomeAtendido.ToUpper()}";
            }

        }

        private void pagDarBaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtUltimoAtendimento_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Devolver();
            }
        }

        private void btnTravarData_Click(object sender, EventArgs e)
        {
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Finalizar();

            //separa as informações pra imprimir e mandar o email.
            string email = "";
            decimal saldoAcumulado = 0.00m;
            
            MySqlDataReader lerVendedor = BancoDeDados.Consultar(
                "SELECT * FROM revendedores WHERE id = @id",
                parametros => { parametros.Parameters.AddWithValue("@id", idVendedor); }
                );

            if (lerVendedor.Read())
            {
                email = lerVendedor["email"].ToString();
                saldoAcumulado = Convert.ToDecimal(lerVendedor["saldo"]);
            }
            else
            {
                MessageBox.Show("Erro inesperado");
                return;
            }

            //cria, imprime e envia por email a planilha desse atendimento
            try
            {
                string caminhoPlan = Utilitarios.CriarPlanilha(nomeAtendido, idAtendimento, saldoAcumulado, pecasEsperadas);

                Utilitarios.EnviarEmailAnexo(email, $"{lerVendedor["nome"].ToString().ToUpper()}, segue, em anexo, a planilha do seu atendimento de hoje.", caminhoPlan);

                Utilitarios.Imprimir(caminhoPlan);
            }
            catch (Exception mensagemErro)
            {
                MessageBox.Show("ERRO", mensagemErro.ToString());
            }

            this.Close();
        }

        private async Task Devolver()
        {
            ///Anti-Burro
            if (dtUltimoAtendimento.Value == new DateTime(1753, 1, 1))
            {
                MessageBox.Show($"O último atendimento de {nomeAtendido.ToUpper()} não foi em 1753!");
                return;
            }
            if (!int.TryParse(txtCodigoDG.Text, out int DG))
            {
                MessageBox.Show($"DG deve ser um número inteiro positivo!");
                return;
            }
            if (DG <= 0)
            {
                MessageBox.Show($"DG deve ser um número inteiro POSITIVO!");
                return;
            }

            //Adiciona o id digitado à lista de peças devolvidas
            pecasDevolvidas.Add(DG);
            txtCodigoDG.Text = "";
            lblResultado.Text = "Peça Devolvida!";

            await Task.Delay(500);
            lblResultado.Text = "";
        }

        private void ReceberEsperadas()
        {
            //Cria a lista de peças que o vendedor levou no último atendimento
            MySqlDataReader listador = BancoDeDados.Consultar(
                "SELECT * FROM lista_pecas WHERE atendimentos_id = @idAtendimento",
                consulta => { consulta.Parameters.AddWithValue("@idAtendimento", idAtendimento); }
                );

            while (listador.Read())
            {
                int peca = Convert.ToInt32(listador["estoque_id_degazin"]);
                pecasEsperadas.Add(peca);
            }
        }

        private void Finalizar()
        {
            //cria a lista de peças baseadas no último atendimento
            int mesIndicador = dtUltimoAtendimento.Value.Month;

            MySqlDataReader idAtend = BancoDeDados.Consultar(
                "SELECT * FROM atendimentos Where data_atendimento = @data",
                parametros => { parametros.Parameters.AddWithValue("@data", dtUltimoAtendimento.Value); }
                );
            if (idAtend.Read())
            {
                idAtendimento = Convert.ToInt32(idAtend["id"]);
            }
            else
            {
                MessageBox.Show("Atendimento não encontrado!", $"Tem certeza que {nomeAtendido.ToUpper()} veio em {dtUltimoAtendimento.Value}?");
                return;
            }
            ReceberEsperadas();

            //cria a lista de peças vendidas com base nas que não voltaram
            pecasVendidas = pecasEsperadas.Except(pecasDevolvidas).ToList();

            //descobre qual foi o montante vendido desde o último atendimento
            decimal valorVendido = 0.00m, valorDivida = 0.00m;

            foreach (int dg in pecasVendidas)
            {
                MySqlDataReader procurarPreco = BancoDeDados.Consultar(
                    "SELECT * FROM estoque WHERE id_degazin = @degazin",
                    consultar => { consultar.Parameters.AddWithValue("@degazin", dg); }
                    );

                if (procurarPreco.Read())
                {
                    decimal precoPeca = Convert.ToDecimal(procurarPreco["preco"]);
                    valorVendido += precoPeca;
                }
                else
                {
                    MessageBox.Show("Erro inesperado!");
                    return;
                }
            }

            //define a dívida de 70% do valor vendido desde o último atendimento
            valorDivida = valorVendido * 0.70m;

            //define a data de entrega do último atendimento como a data atual
            DateTime DataEntrega = DateTime.Today;

            //desliga a segurança
            int desligarSeguranca = BancoDeDados.Executar("SET SQL_SAFE_UPDATES = 0");

            ///atualiza o banco de dados para que os valores NULL do atendimento passado sejam preenchidos

            BancoDeDados.Executar(
                "UPDATE atendimentos SET data_entrega = @hoje," +
                "valor_vendido = @vendeu," +
                "valor_divida = @deve" +
                " WHERE id = @id",

                atualizar =>
                {
                    atualizar.Parameters.AddWithValue("@hoje", DataEntrega);
                    atualizar.Parameters.AddWithValue("@vendeu", valorVendido);
                    atualizar.Parameters.AddWithValue("@deve", valorDivida);
                    atualizar.Parameters.AddWithValue("@id", idAtendimento);
                }
                );

            ///antes de ligar a segurança, atualiza outras tabelas
            foreach (int dg in pecasVendidas)
            {
                //listas_pecas
                BancoDeDados.Executar(
                    "UPDATE lista_pecas SET peca_devolvida = 0 WHERE estoque_id_degazin = @peca",
                    parametros => { parametros.Parameters.AddWithValue("@peca", dg); }
                    );

                //estoque_pecas
                BancoDeDados.Executar(
                    "UPDATE estoque SET data_saida = @hoje WHERE id_degazin = @peca",
                    parametros =>
                    {
                        parametros.Parameters.AddWithValue("@peca", dg);
                        parametros.Parameters.AddWithValue("@hoje", DataEntrega);
                    }
                    );
            }

            //vendedor
            BancoDeDados.Executar(
                "UPDATE revendedores SET saldo = saldo - @divida WHERE id = @id",
                parametros =>
                {
                    parametros.Parameters.AddWithValue("@divida", valorDivida);
                    parametros.Parameters.AddWithValue("@id", idVendedor);
                }
                );

            //liga a segurança
            int ligarSeguranca = BancoDeDados.Executar("SET SQL_SAFE_UPDATES = 1");
        }
    }
}
