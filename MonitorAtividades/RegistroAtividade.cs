namespace MonitorAtividades
{
    public class RegistroAtividade
    {
        public string Aplicacao { get; private set; }
        public string Titulo { get; private set; }
        public DateTime Inicio { get; private set; }
        public int Segundos { get; private set; }

        public RegistroAtividade(string aplicacao, string titulo)
        {
            Aplicacao = aplicacao;
            Titulo = titulo;
            Inicio = DateTime.Now;
            Segundos = 0;
        }

        public void AdicionarSegundo()
        {
            Segundos++;
        }

        public bool EhMesmaJanela(string aplicacao, string titulo)
        {
            return Aplicacao == aplicacao && Titulo == titulo;
        }

        public string GerarLinhaLog()
        {
            return $"{Inicio:dd/MM/yyyy HH:mm:ss} | {Aplicacao} | {Segundos}s | {Titulo}";
        }
    }
}
