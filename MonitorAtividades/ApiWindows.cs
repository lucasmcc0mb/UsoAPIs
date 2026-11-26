using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MonitorAtividades
{
    public class ApiWindows
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint idProcesso);

        public Process? ObterProcessoAtivo()
        {
            IntPtr janela = GetForegroundWindow();
            if (janela == IntPtr.Zero)
            {
                return null;
            }

            GetWindowThreadProcessId(janela, out uint idProcesso);

            try
            {
                return Process.GetProcessById((int)idProcesso);
            }
            catch
            {
                return null;
            }
        }
    }
}
