using MiniExcelLibs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProjetoDegazin
{
    public static class BancoDeDados
    {
        //Indica o caminho do banco
        private static readonly string strConexao = "server=IP;database=DB;user=USER;pwd=PASSWORD;";

        //Cria uma conexão
        public static MySqlConnection AbrirConexao()
        {
            MySqlConnection conexaoBanco = new MySqlConnection(strConexao);
            conexaoBanco.Open();
            return conexaoBanco;
        }

        //Executa um comando SQL, pensado para ALTER, DELETE e UPDATE
        public static int Executar(string strComandoSQL, Action<MySqlCommand> parametros = null)
        {
            using (MySqlConnection conexaoBanco = BancoDeDados.AbrirConexao())
            {
                using (MySqlCommand comando = new MySqlCommand(strComandoSQL, conexaoBanco))
                {
                    parametros?.Invoke(comando);

                    return comando.ExecuteNonQuery();
                }
            }
        }

        //Executa um comando SQL, pensado para INSERT
        public static (int numeroLinhas, long ultimoId) Inserir(string strComandoSQL, Action<MySqlCommand> parametros = null)
        {
            using (MySqlConnection conexaoBanco = BancoDeDados.AbrirConexao())
            {
                using (MySqlCommand comando = new MySqlCommand(strComandoSQL, conexaoBanco))
                {
                    parametros?.Invoke(comando);

                    int linhas = comando.ExecuteNonQuery();
                    long id = comando.LastInsertedId;
                    return (linhas, id);
                }
            }
        }

        //Executa um comando SQL, pensado para SELECT
        public static MySqlDataReader Consultar(string strComandoSQL, Action<MySqlCommand> parametros = null)
        {
            MySqlConnection conexaoBanco = BancoDeDados.AbrirConexao();

            MySqlCommand consulta = new MySqlCommand(strComandoSQL, conexaoBanco);

            parametros?.Invoke(consulta);

            return consulta.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }

    public static class Seguranca
    {
        //Cria uma "hash" de senha, para criptografia
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        //Testa uma "hash" de senha, para proteção
        public static bool ConferirSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

        //Valida um formato de email
        public static bool EmailValido(string email)
        {
            try
            {
                MailAddress endereco = new MailAddress(email);
                return endereco.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    public static class Utilitarios
    {
        //Envia um email com um arquivo de anexo
        public static void EnviarEmailAnexo(string destinatario, string corpo, string caminhoArquivo)
        {

            // O 'using' garante o descarte automático ao final das chaves
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("EMAIL@DOMAIN.COM");
                mail.To.Add(destinatario);
                mail.Subject = "Degazin - Mensagem Automática";
                mail.Body = corpo;
                mail.IsBodyHtml = false;

                // Criando e adicionando o anexo dentro do escopo seguro
                using (Attachment anexo = new Attachment(caminhoArquivo))
                {
                    mail.Attachments.Add(anexo);

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("EMAIL@DOMAIN.COM", "PASSWORD");
                        smtp.EnableSsl = true;

                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao enviar: " + ex.Message);
                        }
                    } // O SmtpClient é fechado e descartado aqui
                } // O arquivo anexo é destravado do sistema operacional aqui
            } // A mensagem de e-mail é limpa da memória aqui
        }

        //Envia um email sem anexo
        public static void EnviarEmail(string destinatario, string corpo)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("EMAIL@DOMAIN.COM");
                mail.To.Add(destinatario);
                mail.Subject = "Degazin - Mensagem Automática";
                mail.Body = corpo;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("EMAIL@DOMAIN.COM", "PASSWORD");
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao enviar: " + ex.Message);
                    }
                }
            }
        }

        //imprime um arquivo
        public static void Imprimir(string caminho)
        {
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = caminho,
                UseShellExecute = true,
                CreateNoWindow = true,
                Verb = "print"
            };

            Process.Start(info);
        }

        public class peca
        {
            public int DG { get; set; }
            public string CodigoOriginal { get; set; }
            public decimal Preco { get; set; }
            public string Descricao { get; set; }
            public string Devolvida { get; set; }
        }

        public static string CriarPlanilha(string nome, int idAtendimento, decimal SaldoAcumulado, List<int> listaDGs)
        {
            List<peca> pecas = new List<peca>();
            int TotalVendidas = 0;
            decimal Montante = 0.00m;

            foreach (int Dg in listaDGs)
            {
                MySqlDataReader leitor = BancoDeDados.Consultar("SELECT * FROM estoque WHERE id_degazin = @id",
                    sql => { sql.Parameters.AddWithValue("@id", Dg); }
                    );

                if (leitor.Read())
                {
                    peca Variavel = new peca();
                    Variavel.DG = Convert.ToInt32(leitor["id_degazin"]);
                    Variavel.CodigoOriginal = leitor["codigo_original"].ToString();
                    Variavel.Preco = Convert.ToDecimal(leitor["preco"]);
                    Variavel.Descricao = leitor["descricao"].ToString().ToUpper();

                    if (leitor["data_saida"] == DBNull.Value)
                    {
                        Variavel.Devolvida = "SIM";
                    }
                    else
                    {
                        Variavel.Devolvida = "NÃO";
                        TotalVendidas++;
                        Montante += Variavel.Preco;
                    }

                    pecas.Add(Variavel);
                }
            }

            var planilha = new
            {
                NomeData = $"{nome}-{DateTime.Today:dd-MM-yyyy}",
                ResumoAtendimento = $"RESUMO ATENDIMENTO {idAtendimento}",
                TotalPecas = pecas.Count(),
                TotalVendidas = TotalVendidas,
                Montante = Montante.ToString("C"),
                Divida = (Montante * 0.70m).ToString("C"),
                Saldo = SaldoAcumulado.ToString("C"),
                Pecas = pecas
            };

            string pastaModelo = Path.Combine(Application.StartupPath, "DOCUMENTOS");

            string caminhoExemplo = Path.Combine(pastaModelo, "PlanTemplate.xlsx");
            
            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            string pastaPlanilhas = Path.Combine(pastaDocumentos, "Degazin", "DOCUMENTOS");
            Directory.CreateDirectory(pastaPlanilhas);
            
            string caminhoSaida = Path.Combine(pastaPlanilhas, $"{nome}-{DateTime.Today:dd-MM-yyyy(ddd)}.xlsx");

            MiniExcel.SaveAsByTemplate(caminhoSaida, caminhoExemplo, planilha);
            return caminhoSaida;
        }

    }
}
