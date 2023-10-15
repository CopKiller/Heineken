using AplicativoPromotor.Pages.ToolsPages;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class PremiumPage : ContentPage
{
    // --> Obtem o ID da p�gina
    private int PageID = (int)PagesSovi.Premium;

    // --> Obtem o status da p�gina
    private bool PageLoading;

    // --> Contrutor padr�o da p�gina
    public PremiumPage()
    {
        // Informa que a p�gina est� em carregamento
        PageLoading = true;

        InitializeComponent();

        // --> Inicializa informa��es compartilhadas das p�ginas do SOVI
        //_ = SharedSoviInfos.InitPages();

        _ = RefreshPremiumData();
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
                case "EntryAllPremium":
                    SharedSoviInfos.Pages[PageID].TotalCentimetros = num;
                    break;
                case "EntryPremium":
                    SharedSoviInfos.Pages[PageID].PortfolioCentimetros = num;
                    break;
                case "EntrySoviHeineken":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)PremiumProdutos.Heineken].produtoSovi = (byte)num;
                    break;
                case "EntrySoviHeineken00":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)PremiumProdutos.Heineken00].produtoSovi = (byte)num;
                    break;
            }

            // Atualiza os dados de cent�metros com base no identificador da Entry e o �ndice
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i + 1;

                if (nomeDoInvocador == ("EntryHeineken" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)PremiumProdutos.Heineken].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntryHeineken00" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)PremiumProdutos.Heineken00].produtoCentimetro[i] = num;

                    break;
                }
            }
            // Atualize a UI, se necess�rio
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EspacoHeineken.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.Premium, PremiumProdutos.Heineken).ToString();
                EspacoHeineken00.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.Premium, PremiumProdutos.Heineken00).ToString();
            });

            // Fix: S� realizar� salvamentos se a p�gina j� estiver carregada
            if (PageLoading == false)
            {
                await SharedSoviInfos.SavePagesToFile();
            }

            // Informa que a p�gina est� carregada e pode iniciar saves
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

    private Task RefreshPremiumData()
    {
        // Lista de controles e propriedades para verificar
        var controlsToCheck = new List<(Entry entry, Func<int> getValue, Func<string> format)>()
{
    (EntryAllPremium, () => SharedSoviInfos.Pages[PageID].TotalCentimetros, () => ""),
    (EntryPremium, () => SharedSoviInfos.Pages[PageID].PortfolioCentimetros, () => ""),
    (EntrySoviHeineken, () => SharedSoviInfos.Pages[PageID].Produtos[(int)PremiumProdutos.Heineken].produtoSovi, () => ""),
    (EntrySoviHeineken00, () => SharedSoviInfos.Pages[PageID].Produtos[(int)PremiumProdutos.Heineken00].produtoSovi, () => ""),
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
        var productControls = new List<(PremiumProdutos produto, Entry[] entries)>()
{
    (PremiumProdutos.Heineken, new Entry[] { EntryHeineken1, EntryHeineken2, EntryHeineken3, EntryHeineken4, EntryHeineken5, EntryHeineken6, EntryHeineken7, EntryHeineken8, EntryHeineken9 }),
    (PremiumProdutos.Heineken00, new Entry[] { EntryHeineken001, EntryHeineken002, EntryHeineken003, EntryHeineken004, EntryHeineken005, EntryHeineken006, EntryHeineken007, EntryHeineken008, EntryHeineken009 })
};

        foreach (var (produto, entries) in productControls)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                Entry entry = entries[i];
                int value = SharedSoviInfos.Pages[PageID].Produtos[(int)produto].produtoCentimetro[i];

                // Verifique se o valor � maior que 0 antes de atribuir
                entry.Text = (value > 0) ? value.ToString() : "";
            }
        }

        return Task.CompletedTask;
    }
}
