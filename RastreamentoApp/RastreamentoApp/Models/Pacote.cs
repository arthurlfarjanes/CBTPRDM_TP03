// Autores:
// - ADRIANO JÚNIOR DE SOUZA ALMEIDA (CB3030644)
// - ARTHUR LANZILOTTI FARJANES (CB3031306)

namespace RastreamentoApp.Models
{
    public class EventoRastreamento
    {
        public string DataHora { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class Pacote
    {
        public string IdPacote { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string DataEnvio { get; set; } = string.Empty;
        public string DataPrevistaEntrega { get; set; } = string.Empty;
        public string LocalizacaoAtual { get; set; } = string.Empty;
        public string CorStatus { get; set; } = "#2563EB";
        public List<EventoRastreamento> HistoricoEventos { get; set; } = new();
    }
}