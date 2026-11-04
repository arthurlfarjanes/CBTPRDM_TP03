// Autores:
// - ADRIANO JÚNIOR DE SOUZA ALMEIDA (CB3030644)
// - ARTHUR LANZILOTTI FARJANES (CB3031306)

using RastreamentoApp.ViewModels;

namespace RastreamentoApp.Views
{
    public partial class BuscaPage : ContentPage
    {
        public BuscaPage()
        {
            InitializeComponent();
            BindingContext = new RastreamentoViewModel();
        }
    }
}