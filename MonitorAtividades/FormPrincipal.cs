namespace MonitorAtividades
{
    public partial class FormPrincipal : Form
    {
        private Monitoramento monitoramento;

        public FormPrincipal()
        {
            InitializeComponent();

            string caminhoLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log_atividades.txt");
            monitoramento = new Monitoramento(caminhoLog);
        }

        private void btnIniciar_Click(object? sender, EventArgs e)
        {
            monitoramento.Iniciar();

            lstApps.Items.Clear();
            txtResumo.Clear();
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
            monitoramento.Atualizar();
            lblJanela.Text = "Janela atual: " + monitoramento.JanelaAtual;

            lstApps.Items.Clear();
            foreach (string linha in monitoramento.ListarTempos())
            {
                lstApps.Items.Add(linha);
            }
        }

        private void PararMonitoramento()
        {
            timer1.Stop();
            monitoramento.Finalizar();

            btnIniciar.Enabled = true;
            btnParar.Enabled = false;
            lblStatus.Text = "Status: Finalizado";
            lblStatus.ForeColor = Color.DimGray;

            txtResumo.Text = monitoramento.GerarResumo();
        }

        private void btnEnviarEmail_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResumo.Text))
            {
                txtResumo.Text = monitoramento.GerarResumo();
            }

            try
            {
                int porta = int.Parse(txtPorta.Text);
                Email email = new Email(txtServidor.Text, porta, txtRemetente.Text, txtSenha.Text, txtDestino.Text);
                email.Enviar("Relatório de Atividades", txtResumo.Text, monitoramento.CaminhoLog);
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
