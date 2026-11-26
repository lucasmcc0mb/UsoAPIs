namespace MonitorAtividades
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblJanela = new Label();
            lblStatus = new Label();
            btnIniciar = new Button();
            btnParar = new Button();
            lblLista = new Label();
            lstApps = new ListBox();
            lblResumo = new Label();
            txtResumo = new TextBox();
            grpEmail = new GroupBox();
            lblServidor = new Label();
            txtServidor = new TextBox();
            lblPorta = new Label();
            txtPorta = new TextBox();
            lblRemetente = new Label();
            txtRemetente = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblDestino = new Label();
            txtDestino = new TextBox();
            btnEnviarEmail = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            grpEmail.SuspendLayout();
            SuspendLayout();

            lblJanela.AutoSize = true;
            lblJanela.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblJanela.Location = new Point(15, 15);
            lblJanela.Name = "lblJanela";
            lblJanela.Size = new Size(150, 17);
            lblJanela.TabIndex = 0;
            lblJanela.Text = "Janela atual: -";

            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.DimGray;
            lblStatus.Location = new Point(15, 38);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status: Parado";

            btnIniciar.Location = new Point(15, 65);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(120, 30);
            btnIniciar.TabIndex = 2;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;

            btnParar.Enabled = false;
            btnParar.Location = new Point(145, 65);
            btnParar.Name = "btnParar";
            btnParar.Size = new Size(150, 30);
            btnParar.TabIndex = 3;
            btnParar.Text = "Parar e Ver Resumo";
            btnParar.UseVisualStyleBackColor = true;
            btnParar.Click += btnParar_Click;

            lblLista.AutoSize = true;
            lblLista.Location = new Point(15, 108);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(130, 15);
            lblLista.TabIndex = 4;
            lblLista.Text = "Tempo por aplicação:";

            lstApps.Location = new Point(15, 128);
            lstApps.Name = "lstApps";
            lstApps.Size = new Size(260, 169);
            lstApps.TabIndex = 5;

            lblResumo.AutoSize = true;
            lblResumo.Location = new Point(290, 108);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new Size(105, 15);
            lblResumo.TabIndex = 6;
            lblResumo.Text = "Resumo da sessão:";

            txtResumo.Location = new Point(290, 128);
            txtResumo.Multiline = true;
            txtResumo.Name = "txtResumo";
            txtResumo.ReadOnly = true;
            txtResumo.ScrollBars = ScrollBars.Vertical;
            txtResumo.Size = new Size(340, 169);
            txtResumo.TabIndex = 7;

            grpEmail.Controls.Add(lblServidor);
            grpEmail.Controls.Add(txtServidor);
            grpEmail.Controls.Add(lblPorta);
            grpEmail.Controls.Add(txtPorta);
            grpEmail.Controls.Add(lblRemetente);
            grpEmail.Controls.Add(txtRemetente);
            grpEmail.Controls.Add(lblSenha);
            grpEmail.Controls.Add(txtSenha);
            grpEmail.Controls.Add(lblDestino);
            grpEmail.Controls.Add(txtDestino);
            grpEmail.Controls.Add(btnEnviarEmail);
            grpEmail.Location = new Point(15, 310);
            grpEmail.Name = "grpEmail";
            grpEmail.Size = new Size(615, 145);
            grpEmail.TabIndex = 8;
            grpEmail.TabStop = false;
            grpEmail.Text = "Enviar Relatório por E-mail (SMTP)";

            lblServidor.AutoSize = true;
            lblServidor.Location = new Point(15, 28);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(55, 15);
            lblServidor.TabIndex = 0;
            lblServidor.Text = "Servidor:";

            txtServidor.Location = new Point(85, 25);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(190, 23);
            txtServidor.TabIndex = 1;
            txtServidor.Text = "smtp.gmail.com";

            lblPorta.AutoSize = true;
            lblPorta.Location = new Point(290, 28);
            lblPorta.Name = "lblPorta";
            lblPorta.Size = new Size(38, 15);
            lblPorta.TabIndex = 2;
            lblPorta.Text = "Porta:";

            txtPorta.Location = new Point(335, 25);
            txtPorta.Name = "txtPorta";
            txtPorta.Size = new Size(65, 23);
            txtPorta.TabIndex = 3;
            txtPorta.Text = "587";

            lblRemetente.AutoSize = true;
            lblRemetente.Location = new Point(15, 62);
            lblRemetente.Name = "lblRemetente";
            lblRemetente.Size = new Size(65, 15);
            lblRemetente.TabIndex = 4;
            lblRemetente.Text = "Seu e-mail:";

            txtRemetente.Location = new Point(85, 59);
            txtRemetente.Name = "txtRemetente";
            txtRemetente.Size = new Size(210, 23);
            txtRemetente.TabIndex = 5;

            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(310, 62);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(42, 15);
            lblSenha.TabIndex = 6;
            lblSenha.Text = "Senha:";

            txtSenha.Location = new Point(360, 59);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(235, 23);
            txtSenha.TabIndex = 7;
            txtSenha.UseSystemPasswordChar = true;

            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(15, 96);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(52, 15);
            lblDestino.TabIndex = 8;
            lblDestino.Text = "Destino:";

            txtDestino.Location = new Point(85, 93);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(290, 23);
            txtDestino.TabIndex = 9;

            btnEnviarEmail.Location = new Point(400, 91);
            btnEnviarEmail.Name = "btnEnviarEmail";
            btnEnviarEmail.Size = new Size(195, 30);
            btnEnviarEmail.TabIndex = 10;
            btnEnviarEmail.Text = "Enviar Relatório por E-mail";
            btnEnviarEmail.UseVisualStyleBackColor = true;
            btnEnviarEmail.Click += btnEnviarEmail_Click;

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 470);
            Controls.Add(lblJanela);
            Controls.Add(lblStatus);
            Controls.Add(btnIniciar);
            Controls.Add(btnParar);
            Controls.Add(lblLista);
            Controls.Add(lstApps);
            Controls.Add(lblResumo);
            Controls.Add(txtResumo);
            Controls.Add(grpEmail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monitor de Atividades (Time Tracker)";
            FormClosing += FormPrincipal_FormClosing;
            grpEmail.ResumeLayout(false);
            grpEmail.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblJanela;
        private Label lblStatus;
        private Button btnIniciar;
        private Button btnParar;
        private Label lblLista;
        private ListBox lstApps;
        private Label lblResumo;
        private TextBox txtResumo;
        private GroupBox grpEmail;
        private Label lblServidor;
        private TextBox txtServidor;
        private Label lblPorta;
        private TextBox txtPorta;
        private Label lblRemetente;
        private TextBox txtRemetente;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblDestino;
        private TextBox txtDestino;
        private Button btnEnviarEmail;
        private System.Windows.Forms.Timer timer1;
    }
}
