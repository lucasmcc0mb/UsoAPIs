using System.Text;

namespace MonitorAtividades
{
    public class Monitoramento
    {
        private ApiWindows api;
        private Dictionary<string, int> tempoPorAplicacao;
        private RegistroAtividade? registroAtual;
        private DateTime inicio;

        public string CaminhoLog { get; private set; }
        public string JanelaAtual { get; private set; }

        public Monitoramento(string caminhoLog)
        {
            api = new ApiWindows();
            tempoPorAplicacao = new Dictionary<string, int>();
            CaminhoLog = caminhoLog;
            JanelaAtual = "-";
        }

        public void Iniciar()
        {
            tempoPorAplicacao.Clear();
            registroAtual = null;
            inicio = DateTime.Now;
            File.WriteAllText(CaminhoLog, "Data/Hora | Aplicacao | Duracao | Titulo" + Environment.NewLine);
        }

        public void Atualizar()
        {
            api.ObterJanelaAtiva(out string aplicacao, out string titulo);
            JanelaAtual = aplicacao + " - " + titulo;

            if (tempoPorAplicacao.ContainsKey(aplicacao))
            {
                tempoPorAplicacao[aplicacao]++;
            }
            else
            {
                tempoPorAplicacao[aplicacao] = 1;
            }

            if (registroAtual == null)
            {
                registroAtual = new RegistroAtividade(aplicacao, titulo);
            }
            else if (!registroAtual.EhMesmaJanela(aplicacao, titulo))
            {
                GravarRegistro(registroAtual);
                registroAtual = new RegistroAtividade(aplicacao, titulo);
            }

            registroAtual.AdicionarSegundo();
        }

        public void Finalizar()
        {
            if (registroAtual != null)
            {
                GravarRegistro(registroAtual);
                registroAtual = null;
            }
        }

        private void GravarRegistro(RegistroAtividade registro)
        {
            File.AppendAllText(CaminhoLog, registro.GerarLinhaLog() + Environment.NewLine);
        }

        public List<string> ListarTempos()
        {
            List<string> linhas = new List<string>();
            foreach (KeyValuePair<string, int> item in tempoPorAplicacao)
            {
                linhas.Add(item.Key + " - " + FormatarTempo(item.Value));
            }
            return linhas;
        }

        public string GerarResumo()
        {
            int totalSegundos = 0;
            foreach (int segundos in tempoPorAplicacao.Values)
            {
                totalSegundos += segundos;
            }

            StringBuilder resumo = new StringBuilder();
            resumo.AppendLine("RESUMO DE USO");
            resumo.AppendLine("Início: " + inicio.ToString("dd/MM/yyyy HH:mm:ss"));
            resumo.AppendLine("Fim: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            resumo.AppendLine("Tempo total: " + FormatarTempo(totalSegundos));
            resumo.AppendLine("----------------------------------------");

            foreach (KeyValuePair<string, int> item in tempoPorAplicacao)
            {
                double porcentagem = 0;
                if (totalSegundos > 0)
                {
                    porcentagem = item.Value * 100.0 / totalSegundos;
                }

                resumo.AppendLine($"{item.Key}: {FormatarTempo(item.Value)} ({porcentagem:0.0}%)");
            }

            resumo.AppendLine("----------------------------------------");
            resumo.AppendLine("Log salvo em: " + CaminhoLog);

            return resumo.ToString();
        }

        private string FormatarTempo(int totalSegundos)
        {
            TimeSpan tempo = TimeSpan.FromSeconds(totalSegundos);
            return tempo.ToString(@"hh\:mm\:ss");
        }
    }
}
