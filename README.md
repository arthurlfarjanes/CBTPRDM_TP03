# 📦 RastreamentoApp - Rastreamento Logístico (.NET MAUI)

> Trabalho Prático 03 desenvolvido para a disciplina de **CBTPRDM - ADS**. 
> Uma aplicação móvel multiplataforma para rastreamento de pacotes em tempo real utilizando o padrão de arquitetura MVVM e dados simulados em memória.

## 👨‍💻 Autores

| Nome | Prontuário |
| :--- | :--- |
| **ADRIANO JÚNIOR DE SOUZA ALMEIDA** | CB3030644 |
| **ARTHUR LANZILOTTI FARJANES** | CB3031306 |

## ✨ Funcionalidades

- [x] **Busca por Código de Rastreio:** Página inicial intuitiva para consulta de pacotes (ex: `BR123456789`, `BR987654321`, `BR555666777`).
- [x] **Atalhos de Teste Rápido:** Chips interativos na tela inicial para preencher códigos de teste automaticamente.
- [x] **Arquitetura MVVM:** Separação clara de responsabilidades entre `Models`, `Views` e `ViewModels`.
- [x] **Detalhes do Pacote:** Exibição de status atual, data de envio, previsão de entrega e localização atual.
- [x] **Histórico de Eventos:** Linha do tempo detalhada exibida com `CollectionView` mostrando cada etapa da movimentação logística.
- [x] **Tratamento de Erros:** Alerta amigável caso o código informado não seja encontrado ou esteja em branco.

## 🛠️ Tecnologias Utilizadas

- **Framework:** .NET MAUI
- **Linguagem:** C#
- **Padrão de Arquitetura:** MVVM (Model-View-ViewModel)
- **Interface:** XAML (Data Binding, Commands, INotifyPropertyChanged, CollectionView, NavigationPage)

## 🚀 Como Executar

1. Clone este repositório em sua máquina local.
2. Abra a solução no **Visual Studio 2022** (certifique-se de ter a carga de trabalho de desenvolvimento com .NET MAUI instalada).
3. Selecione o dispositivo alvo no topo (Ex: *Windows Machine* ou um *Emulador Android*).
4. Clique em **Executar (F5)**.
