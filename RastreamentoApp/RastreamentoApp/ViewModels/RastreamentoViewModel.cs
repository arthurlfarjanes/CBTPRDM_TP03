// Autores:
// - ADRIANO JÚNIOR DE SOUZA ALMEIDA (CB3030644)
// - ARTHUR LANZILOTTI FARJANES (CB3031306)

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RastreamentoApp.Models;
using RastreamentoApp.Views;

namespace RastreamentoApp.ViewModels
{
    public class RastreamentoViewModel : INotifyPropertyChanged
    {
        private string _codigoRastreamento = string.Empty;
        private Pacote? _pacoteEncontrado;
        private readonly List<Pacote> _baseDeDadosSimulada;

        public string CodigoRastreamento
        {
            get => _codigoRastreamento;
            set
            {
                if (_codigoRastreamento != value)
                {
                    _codigoRastreamento = value;
                    OnPropertyChanged();
                }
            }
        }

        public Pacote? PacoteEncontrado
        {
            get => _pacoteEncontrado;
            set
            {
                if (_pacoteEncontrado != value)
                {
                    _pacoteEncontrado = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand BuscarPacoteCommand { get; }
        public ICommand PreencherCodigoCommand { get; }
        public ICommand VoltarCommand { get; }

        public RastreamentoViewModel()
        {
            _baseDeDadosSimulada = CarregarDadosFicticios();

            BuscarPacoteCommand = new Command(async () => await BuscarPacoteAsync());
            PreencherCodigoCommand = new Command<string>((codigo) => CodigoRastreamento = codigo);
            VoltarCommand = new Command(async () =>
            {
                if (Application.Current?.MainPage?.Navigation != null)
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            });
        }

        private async Task BuscarPacoteAsync()
        {
            var paginaPrincipal = Application.Current?.MainPage;
            if (paginaPrincipal == null) return;

            if (string.IsNullOrWhiteSpace(CodigoRastreamento))
            {
                await paginaPrincipal.DisplayAlert(
                    "Campo Obrigatório",
                    "Por favor, digite um código de rastreamento para realizar a consulta.",
                    "OK");
                return;
            }

            string codigoFormatado = CodigoRastreamento.Trim().ToUpper();

            var pacote = _baseDeDadosSimulada.FirstOrDefault(
                p => p.IdPacote.Equals(codigoFormatado, StringComparison.OrdinalIgnoreCase));

            if (pacote == null)
            {
                await paginaPrincipal.DisplayAlert(
                    "Pacote Não Encontrado",
                    $"Nenhum registro encontrado para o código '{codigoFormatado}'.\n\nCódigos válidos para teste:\n• BR123456789\n• BR987654321\n• BR555666777",
                    "Tentar Novamente");
                return;
            }

            PacoteEncontrado = pacote;

            // Navega para a página de resultados compartilhando o mesmo ViewModel
            await paginaPrincipal.Navigation.PushAsync(new ResultadoPage(this));
        }

        private List<Pacote> CarregarDadosFicticios()
        {
            return new List<Pacote>
            {
                new Pacote
                {
                    IdPacote = "BR123456789",
                    Status = "Em Trânsito",
                    CorStatus = "#D97706",
                    DataEnvio = "01/11/2026",
                    DataPrevistaEntrega = "06/11/2026",
                    LocalizacaoAtual = "Centro de Distribuição - Cajamar, SP",
                    HistoricoEventos = new List<EventoRastreamento>
                    {
                        new EventoRastreamento { DataHora = "04/11/2026 - 08:30", Local = "Cajamar, SP", Descricao = "Objeto em trânsito para a unidade de distribuição de Santos, SP." },
                        new EventoRastreamento { DataHora = "03/11/2026 - 19:15", Local = "Cajamar, SP", Descricao = "Objeto recebido no centro de triagem principal." },
                        new EventoRastreamento { DataHora = "02/11/2026 - 14:20", Local = "Curitiba, PR", Descricao = "Objeto despachado para o estado de destino." },
                        new EventoRastreamento { DataHora = "01/11/2026 - 10:05", Local = "Curitiba, PR", Descricao = "Objeto postado na agência logística." }
                    }
                },
                new Pacote
                {
                    IdPacote = "BR987654321",
                    Status = "Entregue",
                    CorStatus = "#16A34A",
                    DataEnvio = "28/10/2026",
                    DataPrevistaEntrega = "02/11/2026",
                    LocalizacaoAtual = "Cubatão, SP (Entregue ao destinatário)",
                    HistoricoEventos = new List<EventoRastreamento>
                    {
                        new EventoRastreamento { DataHora = "02/11/2026 - 16:40", Local = "Cubatão, SP", Descricao = "Objeto entregue ao destinatário." },
                        new EventoRastreamento { DataHora = "02/11/2026 - 08:10", Local = "Cubatão, SP", Descricao = "Objeto saiu para entrega ao destinatário." },
                        new EventoRastreamento { DataHora = "30/10/2026 - 22:00", Local = "São Paulo, SP", Descricao = "Objeto em transferência para a unidade do litoral." },
                        new EventoRastreamento { DataHora = "28/10/2026 - 11:30", Local = "Belo Horizonte, MG", Descricao = "Objeto postado pelo remetente." }
                    }
                },
                new Pacote
                {
                    IdPacote = "BR555666777",
                    Status = "Saiu para Entrega",
                    CorStatus = "#2563EB",
                    DataEnvio = "02/11/2026",
                    DataPrevistaEntrega = "04/11/2026",
                    LocalizacaoAtual = "Em rota de entrega - Santos, SP",
                    HistoricoEventos = new List<EventoRastreamento>
                    {
                        new EventoRastreamento { DataHora = "04/11/2026 - 07:45", Local = "Santos, SP", Descricao = "Objeto saiu para entrega ao destinatário." },
                        new EventoRastreamento { DataHora = "03/11/2026 - 21:30", Local = "Santos, SP", Descricao = "Objeto chegou à unidade de distribuição final." },
                        new EventoRastreamento { DataHora = "02/11/2026 - 15:00", Local = "Campinas, SP", Descricao = "Objeto coletado e processado na origem." }
                    }
                }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}