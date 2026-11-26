using System.Net;
using System.Net.Mail;

namespace MonitorAtividades
{
    public class Email
    {
        public string Servidor { get; set; }
        public int Porta { get; set; }
        public string Remetente { get; set; }
        public string Senha { get; set; }
        public string Destinatario { get; set; }

        public Email(string servidor, int porta, string remetente, string senha, string destinatario)
        {
            Servidor = servidor;
            Porta = porta;
            Remetente = remetente;
            Senha = senha;
            Destinatario = destinatario;
        }

        public void Enviar(string assunto, string mensagemTexto, string caminhoLog)
        {
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(Remetente);
            mensagem.To.Add(Destinatario);
            mensagem.Subject = assunto;
            mensagem.Body = mensagemTexto;

            if (File.Exists(caminhoLog))
            {
                mensagem.Attachments.Add(new Attachment(caminhoLog));
            }

            SmtpClient smtp = new SmtpClient(Servidor, Porta);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(Remetente, Senha);
            smtp.Send(mensagem);

            mensagem.Dispose();
            smtp.Dispose();
        }
    }
}
