namespace MonitorAtividades
{
    public class RegistroAtividade
    {
        public string Aplicacao { get; set; }
        public string Titulo { get; set; }
        public DateTime Inicio { get; set; }
        public int Segundos { get; set; }

        public RegistroAtividade(string aplicacao, string titulo)
        {
            Aplicacao = aplicacao;
            Titulo = titulo;
            Inicio = DateTime.Now;
            Segundos = 0;
        }

        public string GerarLinhaLog()
        {
            return $"{Inicio:dd/MM/yyyy HH:mm:ss} | {Aplicacao} | {Segundos}s | {Titulo}";
        }
    }
}
