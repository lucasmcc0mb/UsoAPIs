using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace MonitorAtividades
{
    public class ApiWindows
    {
        // Retorna o identificador (handle) da janela que está em primeiro plano
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // Retorna a quantidade de caracteres do título da janela
        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        // Copia o título da janela para o StringBuilder
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder texto, int tamanhoMaximo);

        // Retorna o id do processo (programa) dono da janela
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint idProcesso);

        public void ObterJanelaAtiva(out string aplicacao, out string titulo)
        {
            aplicacao = "Desconhecido";
            titulo = "(sem título)";

            // Pega a janela que o usuário está usando agora
            IntPtr janela = GetForegroundWindow();
            if (janela == IntPtr.Zero)
            {
                return;
            }

            // Lê o título da janela usando o tamanho informado pelo Windows
            int tamanho = GetWindowTextLength(janela);
            if (tamanho > 0)
            {
                StringBuilder texto = new StringBuilder(tamanho + 1);
                GetWindowText(janela, texto, texto.Capacity);
                titulo = texto.ToString();
            }

            // Descobre o processo da janela e, a partir dele, o nome do programa
            GetWindowThreadProcessId(janela, out uint idProcesso);
            try
            {
                using (Process processo = Process.GetProcessById((int)idProcesso))
                {
                    aplicacao = processo.ProcessName;
                }
            }
            catch
            {
                aplicacao = "Desconhecido";
            }
        }
    }
}
