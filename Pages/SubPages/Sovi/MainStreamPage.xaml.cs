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
            return; // N�o faz nada se o texto estiver vazio
        }

        if (!double.TryParse(e.NewTextValue, out var num))
        {
            ((Entry)sender).Text = ""; // Limpa o texto se n�o for um n�mero v�lido
        }
        else
        {
            var nomeDoInvocador = ((Entry)sender).ClassId;

            switch (nomeDoInvocador)
            {
                case "EntrySoviBadden":
                    {
                        num = Math.Max(0, Math.Min(num, 100)); // Limita o n�mero entre 0 e 100
                        ((Entry)sender).Text = num.ToString();
                        break;
                    }
                    // Adicione mais casos aqui, se necess�rio
            }
        }
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Crie a p�gina que voc� deseja abrir (por exemplo, NovaPagina)
        var novaPagina = new PdfViewerPage();

        // Use a navega��o do Shell para abrir a nova p�gina
        await Shell.Current.Navigation.PushAsync(novaPagina);
    }
}
