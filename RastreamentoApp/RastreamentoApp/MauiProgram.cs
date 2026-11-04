// ============================================================================
// Trabalho Prático 03 - CBTPRDM
// Autores:
// - ADRIANO JÚNIOR DE SOUZA ALMEIDA (Prontuário: CB3030644)
// - ARTHUR LANZILOTTI FARJANES (Prontuário: CB3031306)
// ============================================================================

using Microsoft.Extensions.Logging;

namespace RastreamentoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}