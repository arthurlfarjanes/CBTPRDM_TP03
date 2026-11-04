// Autores:
// - ADRIANO JÚNIOR DE SOUZA ALMEIDA (CB3030644)
// - ARTHUR LANZILOTTI FARJANES (CB3031306)

using RastreamentoApp.Views;

namespace RastreamentoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BuscaPage())
            {
                BarBackgroundColor = Color.FromArgb("#1E3A8A"),
                BarTextColor = Colors.White
            };
        }
    }
}