using AplicativoPromotor.Pages.ToolsPages;
using System.Diagnostics;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class ResumoPage : ContentPage
{
    public ResumoPage()
    {
        InitializeComponent();

        RefreshResumoData();
    }

    //private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    //{

    //    // Obtém o novo texto e o identificador da Entry que acionou o evento
    //    //string newTextValue = e.NewTextValue;
    //    //string nomeDoInvocador = ((Entry)sender).ClassId;
    //}

    // --> Botão que inicia a leitura do PDF de Sovi
    //private async void OnButtonClicked(object sender, EventArgs e)
    //{
    //}

    private Task RefreshResumoData()
    {
        // Obtenha a data atual e atualize o controle
        DateTime currentDate = DateTime.Now;
        DataAtual.Text += currentDate.ToString("dd/MM/yyyy");

        return Task.CompletedTask;
    }
}
