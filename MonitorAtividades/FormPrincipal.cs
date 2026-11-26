using System.Diagnostics;
using System.Text;

namespace MonitorAtividades
{
    public partial class FormPrincipal : Form
    {
        private ApiWindows api;
        private Dictionary<string, int> tempoPorApp;
        private RegistroAtividade? registroAtual;
        private string caminhoLog;
        private DateTime inicioSessao;

        public FormPrincipal()
        {
            InitializeComponent();
            api = new ApiWindows();
            tempoPorApp = new Dictionary<string, int>();
            caminhoLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log_atividades.txt");
        }

        private void btnIniciar_Click(object? sender, EventArgs e)
        {
            tempoPorApp.Clear();
            lstApps.Items.Clear();
            txtResumo.Clear();
            registroAtual = null;
            inicioSessao = DateTime.Now;

            File.WriteAllText(caminhoLog, "Data/Hora | Aplicacao | Duracao | Titulo" + Environment.NewLine);

            timer1.Start();
            btnIniciar.Enabled = false;
            btnParar.Enabled = true;
            lblStatus.Text = "Status: Monitorando...";
            lblStatus.ForeColor = Color.Green;
        }

        private void btnParar_Click(object? sender, EventArgs e)
        {
            PararMonitoramento();
            MessageBox.Show(txtResumo.Text, "Resumo da Sessão");
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            string app = "Desconhecido";
            string titulo = "(sem título)";

            using (Process? processo = api.ObterProcessoAtivo())
            {
                if (processo != null)
                {
                    app = processo.ProcessName;
                    if (!string.IsNullOrEmpty(processo.MainWindowTitle))
                    {
                        titulo = processo.MainWindowTitle;
                    }
                }
            }

            lblJanela.Text = "Janela atual: " + app + " - " + titulo;

            if (tempoPorApp.ContainsKey(app))
            {
                tempoPorApp[app] = tempoPorApp[app] + 1;
            }
            else
            {
                tempoPorApp[app] = 1;
            }

            if (registroAtual == null)
            {
                registroAtual = new RegistroAtividade(app, titulo);
                registroAtual.Segundos = 1;
            }
            else if (registroAtual.Aplicacao == app && registroAtual.Titulo == titulo)
            {
                registroAtual.Segundos = registroAtual.Segundos + 1;
            }
            else
            {
                File.AppendAllText(caminhoLog, registroAtual.GerarLinhaLog() + Environment.NewLine);
                registroAtual = new RegistroAtividade(app, titulo);
                registroAtual.Segundos = 1;
            }

            AtualizarLista();
        }

        private void AtualizarLista()
        {
            lstApps.Items.Clear();
            foreach (KeyValuePair<string, int> item in tempoPorApp)
            {
                lstApps.Items.Add(item.Key + " - " + FormatarTempo(item.Value));
            }
        }

        private void PararMonitoramento()
        {
            timer1.Stop();

            if (registroAtual != null)
            {
                File.AppendAllText(caminhoLog, registroAtual.GerarLinhaLog() + Environment.NewLine);
                registroAtual = null;
            }

            btnIniciar.Enabled = true;
            btnParar.Enabled = false;
            lblStatus.Text = "Status: Finalizado";
            lblStatus.ForeColor = Color.DimGray;

            txtResumo.Text = GerarResumo();
        }

        private string GerarResumo()
        {
            int totalSegundos = 0;
            foreach (int segundos in tempoPorApp.Values)
            {
                totalSegundos = totalSegundos + segundos;
            }

            StringBuilder resumo = new StringBuilder();
            resumo.AppendLine("RESUMO DE USO");
            resumo.AppendLine("Início: " + inicioSessao.ToString("dd/MM/yyyy HH:mm:ss"));
            resumo.AppendLine("Fim: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            resumo.AppendLine("Tempo total: " + FormatarTempo(totalSegundos));
            resumo.AppendLine("----------------------------------------");

            foreach (KeyValuePair<string, int> item in tempoPorApp)
            {
                double porcentagem = 0;
                if (totalSegundos > 0)
                {
                    porcentagem = (item.Value * 100.0) / totalSegundos;
                }

                resumo.AppendLine($"{item.Key}: {FormatarTempo(item.Value)} ({porcentagem:0.0}%)");
            }

            resumo.AppendLine("----------------------------------------");
            resumo.AppendLine("Log salvo em: " + caminhoLog);

            return resumo.ToString();
        }

        private string FormatarTempo(int totalSegundos)
        {
            TimeSpan tempo = TimeSpan.FromSeconds(totalSegundos);
            return tempo.ToString(@"hh\:mm\:ss");
        }

        private void btnEnviarEmail_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResumo.Text))
            {
                txtResumo.Text = GerarResumo();
            }

            try
            {
                int porta = int.Parse(txtPorta.Text);
                Email email = new Email(txtServidor.Text, porta, txtRemetente.Text, txtSenha.Text, txtDestino.Text);
                email.Enviar("Relatório de Atividades", txtResumo.Text, caminhoLog);
                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar e-mail: " + ex.Message);
            }
        }

        private void FormPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (timer1.Enabled)
            {
                PararMonitoramento();
                MessageBox.Show(txtResumo.Text, "Resumo da Sessão");
            }
        }
    }
}
