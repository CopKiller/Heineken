using AplicativoPromotor.Pages.ToolsPages;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class MainStreamPage : ContentPage
{
    // --> Obtem o ID da página
    private int PageID = (int)PagesSovi.MainStream;

    // --> Obtem o status da página
    private bool PageLoading;

    // --> Contrutor padrão da página
    public MainStreamPage()
    {
        // Informa que a página está em carregamento
        PageLoading = true;

        InitializeComponent();

        // --> Inicializa informações compartilhadas das páginas do SOVI
        //_ = SharedSoviInfos.InitPages();

        _ = RefreshMainStreamData();
    }

    private CancellationTokenSource textChangeTokenSource = new CancellationTokenSource();

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Cancela a tarefa anterior se existir, para evitar múltiplas execuções
        textChangeTokenSource.Cancel();

        // Cria uma nova tarefa com um atraso de 500 ms
        textChangeTokenSource = new CancellationTokenSource();
        CancellationToken token = textChangeTokenSource.Token;

        Task.Delay(500, token).ContinueWith(async (task) =>
        {
            // Verifique se a tarefa foi cancelada (caso uma entrada adicional ocorra)
            if (task.IsCanceled) return;

            // Obtém o novo texto e o identificador da Entry que acionou o evento
            string newTextValue = e.NewTextValue;
            string nomeDoInvocador = ((Entry)sender).ClassId;

            // Verifique se as propriedades são válidas
            // Aqui você pode adicionar mais validações se necessário

            if (!int.TryParse(newTextValue, out var num) || string.IsNullOrEmpty(newTextValue))
            {
                num = 0; // Zera o valor se não for válido
            }

            // Limita números entre 0 e 100 com base no identificador da Entry
            switch (nomeDoInvocador)
            {
                case "EntryAllMainStream":
                    SharedSoviInfos.Pages[PageID].TotalCentimetros = num;
                    break;
                case "EntryMainStream":
                    SharedSoviInfos.Pages[PageID].PortfolioCentimetros = num;
                    break;
                case "EntrySoviAmstel":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)MainStreamProdutos.Amstel].produtoSovi = (byte)num;
                    break;
                case "EntrySoviDevassa":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)MainStreamProdutos.Devassa].produtoSovi = (byte)num;
                    break;
            }

            // Atualiza os dados de centímetros com base no identificador da Entry e o índice
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i + 1;

                if (nomeDoInvocador == ("EntryAmstel" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)MainStreamProdutos.Amstel].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntryDevassa" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)MainStreamProdutos.Devassa].produtoCentimetro[i] = num;

                    break;
                }
            }
            // Atualize a UI, se necessário
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EspacoAmstel.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.MainStream, MainStreamProdutos.Amstel).ToString();
                EspacoDevassa.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.MainStream, MainStreamProdutos.Devassa).ToString();
            });

            // Fix: Só realizará salvamentos se a página já estiver carregada
            if (PageLoading == false)
            {
                await SharedSoviInfos.SavePagesToFile();
            }

            // Informa que a página está carregada e pode iniciar saves
            PageLoading = false;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    // --> Botão que inicia a leitura do PDF de Sovi
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Crie a página que você deseja abrir (por exemplo, NovaPagina)
        var novaPagina = new PdfViewerPage();

        // Use a navegação do Shell para abrir a nova página
        await Shell.Current.Navigation.PushAsync(novaPagina);
    }

    private async Task RefreshMainStreamData()
    {
        // Lista de controles e propriedades para verificar
        var controlsToCheck = new List<(Entry entry, Func<int> getValue, Func<string> format)>()
{
    (EntryAllMainStream, () => SharedSoviInfos.Pages[PageID].TotalCentimetros, () => ""),
    (EntryMainStream, () => SharedSoviInfos.Pages[PageID].PortfolioCentimetros, () => ""),
    (EntrySoviAmstel, () => SharedSoviInfos.Pages[PageID].Produtos[(int)MainStreamProdutos.Amstel].produtoSovi, () => ""),
    (EntrySoviDevassa, () => SharedSoviInfos.Pages[PageID].Produtos[(int)MainStreamProdutos.Devassa].produtoSovi, () => ""),
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
        var productControls = new List<(MainStreamProdutos produto, Entry[] entries)>()
{
    (MainStreamProdutos.Amstel, new Entry[] { EntryAmstel1, EntryAmstel2, EntryAmstel3, EntryAmstel4, EntryAmstel5, EntryAmstel6, EntryAmstel7, EntryAmstel8, EntryAmstel9 }),
    (MainStreamProdutos.Devassa, new Entry[] { EntryDevassa1, EntryDevassa2, EntryDevassa3, EntryDevassa4, EntryDevassa5, EntryDevassa6, EntryDevassa7, EntryDevassa8, EntryDevassa9 })
};

        foreach (var (produto, entries) in productControls)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                Entry entry = entries[i];
                int value = SharedSoviInfos.Pages[PageID].Produtos[(int)produto].produtoCentimetro[i];

                // Verifique se o valor é maior que 0 antes de atribuir
                entry.Text = (value > 0) ? value.ToString() : "";
            }
        }

        return;
    }
}
