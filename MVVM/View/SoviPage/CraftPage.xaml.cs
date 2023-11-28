using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.Pages.ToolsPages;
using System.Diagnostics;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class CraftPage : ContentPage
{

    // --> Obtem o ID da p�gina
    private int PageID = (int)PagesSovi.Craft;
    // --> Obtem o status da p�gina
    private bool PageLoading = false;

    // --> Contrutor padr�o da p�gina
    public CraftPage()
    {
        InitializeComponent();

        _ = InitializePage();
    }

    private Task InitializePage()
    {
        // Informa que a p�gina est� em carregamento
        PageLoading = true;

        // --> Inicializa informa��es compartilhadas das p�ginas do SOVI
        _ = SharedSoviInfos.InitPages();

        // --> Faz o carregamento dos ultimos dados salvos
        _ = RefreshCraftData();

        return Task.CompletedTask;
    }

    private CancellationTokenSource textChangeTokenSource = new CancellationTokenSource();

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Cancela a tarefa anterior se existir, para evitar m�ltiplas execu��es
        textChangeTokenSource.Cancel();

        // Cria uma nova tarefa com um atraso de 500 ms
        textChangeTokenSource = new CancellationTokenSource();
        CancellationToken token = textChangeTokenSource.Token;

        Task.Delay(500, token).ContinueWith(async (task) =>
        {
            // Verifique se a tarefa foi cancelada (caso uma entrada adicional ocorra)
            if (task.IsCanceled) return;

            // Obt�m o novo texto e o identificador da Entry que acionou o evento
            string newTextValue = e.NewTextValue;
            string nomeDoInvocador = ((Entry)sender).ClassId;

            // Verifique se as propriedades s�o v�lidas
            // Aqui voc� pode adicionar mais valida��es se necess�rio

            if (!int.TryParse(newTextValue, out var num) || string.IsNullOrEmpty(newTextValue))
            {
                num = 0; // Zera o valor se n�o for v�lido
            }

            // Limita n�meros entre 0 e 100 com base no identificador da Entry
            switch (nomeDoInvocador)
            {
                case "EntryAllCraft":
                    SharedSoviInfos.PagesData[PageID].TotalCentimetros = num;
                    break;
                case "EntryCraft":
                    SharedSoviInfos.PagesData[PageID].PortfolioCentimetros = num;
                    break;
                case "EntrySoviBadden":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Badden].produtoSovi = (byte)num;
                    break;
                case "EntrySoviBluemoon":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Bluemoon].produtoSovi = (byte)num;
                    break;
                case "EntrySoviLagunitas":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Lagunitas].produtoSovi = (byte)num;
                    break;
            }

            // Atualiza os dados de cent�metros com base no identificador da Entry e o �ndice
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i + 1;

                if (nomeDoInvocador == ("EntryBadden" + indiceReal.ToString()))
                {
                    SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Badden].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntryBluemoon" + indiceReal.ToString()))
                {
                    SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Bluemoon].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntryLagunitas" + indiceReal.ToString()))
                {
                    SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Lagunitas].produtoCentimetro[i] = num;

                    break;
                }
            }
            // Atualize a UI, se necess�rio
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EspacoBadden.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, CraftProducts.Badden).ToString();
                EspacoBluemoon.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, CraftProducts.Bluemoon).ToString();
                EspacoLagunitas.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, CraftProducts.Lagunitas).ToString();
            });

            // Fix: S� realizar� salvamentos se a p�gina j� estiver carregada
            if (PageLoading == false)
            {
                await SharedSoviInfos.SavePagesToFile();
            }

            // Informa que a p�gina est� carregada e ja foi preenchida
            PageLoading = false;

        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    // --> Bot�o que inicia a leitura do PDF de Sovi
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Crie a p�gina que voc� deseja abrir (por exemplo, NovaPagina)
        var novaPagina = new PdfViewerPage();

        // Use a navega��o do Shell para abrir a nova p�gina
        await Shell.Current.Navigation.PushAsync(novaPagina);
    }

    private async Task RefreshCraftData()
    {
        SharedSoviInfos.PagesData = await SharedSoviInfos.ReadPagesFromFile();

        // Lista de controles e propriedades para verificar
        var controlsToCheck = new List<(Entry entry, Func<int> getValue, Func<string> format)>()
{
    (EntryAllCraft, () => SharedSoviInfos.PagesData[PageID].TotalCentimetros, () => ""),
    (EntryCraft, () => SharedSoviInfos.PagesData[PageID].PortfolioCentimetros, () => ""),
    (EntrySoviBadden, () => SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Badden].produtoSovi, () => ""),
    (EntrySoviBluemoon, () => SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Bluemoon].produtoSovi, () => ""),
    (EntrySoviLagunitas, () => SharedSoviInfos.PagesData[PageID].Produtos[(int)CraftProducts.Lagunitas].produtoSovi, () => "")
};

        foreach (var (Entry, getValue, format) in controlsToCheck)
        {
            int value = getValue();
            if (value > 0)
            {
                Entry.Text = value.ToString();
            }
            else
            {
                Entry.Text = format();
            }
        }


        // Crie uma lista de controle para cada produto com suas respectivas lambda expressions
        var productControls = new List<(CraftProducts produto, Entry[] entries)>()
{
    (CraftProducts.Badden, new Entry[] { EntryBadden1, EntryBadden2, EntryBadden3, EntryBadden4, EntryBadden5, EntryBadden6, EntryBadden7, EntryBadden8, EntryBadden9 }),
    (CraftProducts.Bluemoon, new Entry[] { EntryBluemoon1, EntryBluemoon2, EntryBluemoon3, EntryBluemoon4, EntryBluemoon5, EntryBluemoon6, EntryBluemoon7, EntryBluemoon8, EntryBluemoon9 }),
    (CraftProducts.Lagunitas, new Entry[] { EntryLagunitas1, EntryLagunitas2, EntryLagunitas3, EntryLagunitas4, EntryLagunitas5, EntryLagunitas6, EntryLagunitas7, EntryLagunitas8, EntryLagunitas9 })
};

        foreach (var (produto, entries) in productControls)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                Entry entry = entries[i];
                int value = SharedSoviInfos.PagesData[PageID].Produtos[(int)produto].produtoCentimetro[i];

                // Verifique se o valor � maior que 0 antes de atribuir
                entry.Text = (value > 0) ? value.ToString() : "";
            }
        }

        return;
    }
}
