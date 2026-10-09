using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public partial class pagRegistroRev : Form
    {
        int idUsuario, idVendedor, idAtendimento;
        public pagRegistroRev(int IdUsuario, int IdVendedor)
        {
            InitializeComponent();
            this.idUsuario = IdUsuario;
            this.idVendedor = IdVendedor;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Registrar();
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pagRegistro_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";

            MySqlDataReader leitor = BancoDeDados.Consultar(
                "SELECT * FROM revendedores WHERE id = @id",
                parametros => { parametros.Parameters.AddWithValue("@id", idVendedor); }
                );
            if (leitor.Read())
            {
                string nomeAtendido = leitor["nome"].ToString();
                lblAtendido.Text = $"Registro de peça para {nomeAtendido.ToUpper()}";
            }
            
            ///data do atendimento
            DateTime dataAtendimento = DateTime.Today;
            
            ///Mês indicador
            int mesIndicador = dataAtendimento.Month;

            ///Criando novo atendimento:
            var atendimento = BancoDeDados.Inserir(
                "INSERT INTO atendimentos(mes_indicador, data_atendimento, usuarios_id, revendedores_id)"
                + " VALUES (@mes, @data, @idUsuario, @idVendedor)",
                parametros =>
                {
                    parametros.Parameters.AddWithValue("@mes", mesIndicador);
                    parametros.Parameters.AddWithValue("@data", dataAtendimento);
                    parametros.Parameters.AddWithValue("@idUsuario", idUsuario);
                    parametros.Parameters.AddWithValue("@idVendedor", idVendedor);
                }
                );

            if (atendimento.numeroLinhas > 0)
            {
                idAtendimento = Convert.ToInt32(atendimento.ultimoId);
                MessageBox.Show($"Atendimento {idAtendimento} Iniciado!\n");
            }
        }

        private async Task Registrar()
        {
            ///Anti-Burro

            if (!int.TryParse(txtCodigoDG.Text, out int DG))
            {
                MessageBox.Show("O código DG é um número inteiro positivo!");
                return;
            }
            if (DG <= 0 )
            { 
                MessageBox.Show("O código DG é um número inteiro POSITIVO!");
                return;
            }

            try //adiciona o DG à lista_peças com o índice desse atendimento
            {
                var registro = BancoDeDados.Inserir(
                "INSERT INTO lista_pecas(atendimentos_id, estoque_id_degazin)" +
                " VALUES(@idAtendimento, @idDegazin)",

                parametros => //cria um 'método instantâneo' que substitui o valor do NULL nos parâmetros da função
                {
                    parametros.Parameters.AddWithValue("@idAtendimento", idAtendimento);
                    parametros.Parameters.AddWithValue("@idDegazin", DG);
                }
                );

                lblResultado.Text = "Peça Registrada!";
                
                await Task.Delay(500);
                lblResultado.Text = "";
                txtCodigoDG.Text = "";
            }
            catch (MySqlException) //não encontrou a peça
            {
                MessageBox.Show("Peça não encontrada no estoque!");
                return;
            }

        }
    }
}
