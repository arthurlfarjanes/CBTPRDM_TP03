// Autores:
// - ADRIANO JÚNIOR DE SOUZA ALMEIDA (CB3030644)
// - ARTHUR LANZILOTTI FARJANES (CB3031306)

using RastreamentoApp.ViewModels;

namespace RastreamentoApp.Views
{
    public partial class ResultadoPage : ContentPage
    {
        public ResultadoPage(RastreamentoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}