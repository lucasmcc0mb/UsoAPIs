using System.Net;
using System.Net.Mail;

namespace MonitorAtividades
{
    public class Email
    {
        private string senha;

        public string Servidor { get; private set; }
        public int Porta { get; private set; }
        public string Remetente { get; private set; }
        public string Destinatario { get; private set; }

        public Email(string servidor, int porta, string remetente, string senha, string destinatario)
        {
            Servidor = servidor;
            Porta = porta;
            Remetente = remetente;
            this.senha = senha;
            Destinatario = destinatario;
        }

        public void Enviar(string assunto, string corpo, string caminhoAnexo)
        {
            // O using libera a mensagem e o anexo ao final, mesmo se o envio der erro
            using (MailMessage mensagem = new MailMessage())
            using (SmtpClient smtp = new SmtpClient(Servidor, Porta))
            {
                // Monta o e-mail: remetente, destinatário, assunto e texto do resumo
                mensagem.From = new MailAddress(Remetente);
                mensagem.To.Add(Destinatario);
                mensagem.Subject = assunto;
                mensagem.Body = corpo;

                // Anexa o arquivo de log da sessão
                if (File.Exists(caminhoAnexo))
                {
                    mensagem.Attachments.Add(new Attachment(caminhoAnexo));
                }

                // Conecta ao servidor SMTP com criptografia (SSL/TLS), faz login e envia
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(Remetente, senha);
                smtp.Send(mensagem);
            }
        }
    }
}
