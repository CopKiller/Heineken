using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.Pages.ToolsPages;

namespace AplicativoPromotor.MVVM.View.SoviPage;
public partial class PremiumPage : ContentPage
{
    // --> Obtem o ID da página
    private int PageID = (int)PagesSovi.Premium;

    // --> Obtem o status da página
    private bool PageLoading;

    // --> Contrutor padrão da página
    public PremiumPage()
    {
        // Informa que a página está em carregamento
        PageLoading = true;

        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        RefreshPremiumData();
    }

    private Task RefreshPremiumData()
    {
        // Lista de controles e propriedades para verificar
        var controlsToCheck = new List<(Entry entry, Func<int> getValue, Func<string> format)>()
{
    (EntryAllPremium, () => SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].TotalCentimetros, () => ""),
    (EntryPremium, () => SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].PortfolioCentimetros, () => ""),
    (EntrySoviHeineken, () => SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Heineken].produtoSovi, () => ""),
    (EntrySoviHeineken00, () => SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Heineken00].produtoSovi, () => ""),
    (EntrySoviEisenbahn, () => SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Eisenbahn].produtoSovi, () => ""),
    (EntrySoviSol, () => SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Sol].produtoSovi, () => ""),
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
        var productControls = new List<(PremiumProducts produto, Entry[] entries)>()
{
    (PremiumProducts.Heineken, new Entry[] { EntryHeineken1, EntryHeineken2, EntryHeineken3, EntryHeineken4, EntryHeineken5, EntryHeineken6, EntryHeineken7, EntryHeineken8, EntryHeineken9 }),
    (PremiumProducts.Heineken00, new Entry[] { EntryHeineken001, EntryHeineken002, EntryHeineken003, EntryHeineken004, EntryHeineken005, EntryHeineken006, EntryHeineken007, EntryHeineken008, EntryHeineken009 }),
    (PremiumProducts.Eisenbahn, new Entry[] { EntryEisenbahn1, EntryEisenbahn2, EntryEisenbahn3, EntryEisenbahn4, EntryEisenbahn5, EntryEisenbahn6, EntryEisenbahn7, EntryEisenbahn8, EntryEisenbahn9 }),
    (PremiumProducts.Sol, new Entry[] { EntrySol1, EntrySol2, EntrySol3, EntrySol4, EntrySol5, EntrySol6, EntrySol7, EntrySol8, EntrySol9 })
};

        foreach (var (produto, entries) in productControls)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                Entry entry = entries[i];
                int value = SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)produto].produtoCentimetro[i];

                // Verifique se o valor é maior que 0 antes de atribuir
                entry.Text = (value > 0) ? value.ToString() : "";
            }
        }

        return Task.CompletedTask;
    }

    private CancellationTokenSource textChangeTokenSource = new CancellationTokenSource();

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Cancela a tarefa anterior se existir, para evitar múltiplas execuções
        textChangeTokenSource.Cancel();

        // Cria uma nova tarefa com um atraso de 500 ms
        textChangeTokenSource = new CancellationTokenSource();
        CancellationToken token = textChangeTokenSource.Token;

        Task.Delay(500, token).ContinueWith((task) =>
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
                case "EntryAllPremium":
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].TotalCentimetros = num;
                    break;
                case "EntryPremium":
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].PortfolioCentimetros = num;
                    break;
                case "EntrySoviHeineken":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Heineken].produtoSovi = (byte)num;
                    break;
                case "EntrySoviHeineken00":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Heineken00].produtoSovi = (byte)num;
                    break;
                case "EntrySoviEisenbahn":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Eisenbahn].produtoSovi = (byte)num;
                    break;
                case "EntrySoviSol":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Sol].produtoSovi = (byte)num;
                    break;
            }

            // Atualiza os dados de centímetros com base no identificador da Entry e o índice
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i + 1;

                if (nomeDoInvocador == ("EntryHeineken" + indiceReal.ToString()))
                {
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Heineken].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntryHeineken00" + indiceReal.ToString()))
                {
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Heineken00].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntryEisenbahn" + indiceReal.ToString()))
                {
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Eisenbahn].produtoCentimetro[i] = num;

                    break;
                }
                else if (nomeDoInvocador == ("EntrySol" + indiceReal.ToString()))
                {
                    SharedSoviInfos.SharedPerfil.Perfil[SharedSoviInfos.SharedPerfil.SelectedPerfil].PagesSovi[PageID].Produtos[(int)PremiumProducts.Sol].produtoCentimetro[i] = num;

                    break;
                }
            }
            // Atualize a UI, se necessário
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EspacoHeineken.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Premium, PremiumProducts.Heineken).ToString();
                EspacoHeineken00.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Premium, PremiumProducts.Heineken00).ToString();
                EspacoEisenbahn.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Premium, PremiumProducts.Eisenbahn).ToString();
                EspacoSol.Text = SharedSoviInfos.GetProductSpace(PagesSovi.Premium, PremiumProducts.Sol).ToString();
            });

            // Fix: Só realizará salvamentos se a página já estiver carregada
            if (PageLoading == false)
            {
                SharedSoviInfos.SavePagesToFile();
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
}
