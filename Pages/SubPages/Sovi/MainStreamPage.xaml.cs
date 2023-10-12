using AplicativoPromotor.Pages.ToolsPages;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class MainStreamPage : ContentPage
{
    public MainStreamPage()
    {
        InitializeComponent();

        // Assine o evento TextChanged
        //SearchEntry.TextChanged += OnSearchTextChanged;
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
            return; // Não faz nada se o texto estiver vazio
        }

        if (!double.TryParse(e.NewTextValue, out var num))
        {
            ((Entry)sender).Text = ""; // Limpa o texto se não for um número válido
        }
        else
        {
            var nomeDoInvocador = ((Entry)sender).ClassId;

            switch (nomeDoInvocador)
            {
                case "EntrySoviBadden":
                    {
                        num = Math.Max(0, Math.Min(num, 100)); // Limita o número entre 0 e 100
                        ((Entry)sender).Text = num.ToString();
                        break;
                    }
                    // Adicione mais casos aqui, se necessário
            }
        }
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Crie a página que você deseja abrir (por exemplo, NovaPagina)
        var novaPagina = new PdfViewerPage();

        // Use a navegação do Shell para abrir a nova página
        await Shell.Current.Navigation.PushAsync(novaPagina);
    }
}
