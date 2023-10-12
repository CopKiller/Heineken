
using System;
using System.Diagnostics;
using AplicativoPromotor.Pages.ToolsPages;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class CraftPage : ContentPage
{
    // --> Obtem o ID da p�gina
    private int PageID = (int)PagesSovi.Craft;

    // --> Contrutor padr�o da p�gina
    public CraftPage()
    {
        InitializeComponent();

        _ = InitializePageAsync();
    }

    private async Task InitializePageAsync()
    {
        // --> Inicializa informa��es compartilhadas das p�ginas do SOVI
        await SharedSoviInfos.InitPages();

        // --> Faz o carregamento dos ultimos dados salvos
        await RefreshCraftData();
    }

    private CancellationTokenSource textChangeTokenSource = new CancellationTokenSource();

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Cancela a tarefa anterior se existir, para evitar m�ltiplas execu��es
        textChangeTokenSource.Cancel();

        // Cria uma nova tarefa com um atraso de 500 ms
        textChangeTokenSource = new CancellationTokenSource();
        CancellationToken token = textChangeTokenSource.Token;

        Task.Delay(500, token).ContinueWith((task) =>
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
                    SharedSoviInfos.Pages[PageID].TotalCentimetros = num;
                    break;
                case "EntryCraft":
                    SharedSoviInfos.Pages[PageID].PortfolioCentimetros = num;
                    break;
                case "EntrySoviBadden":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Badden].ProdutoSovi = (byte)num;
                    break;
                case "EntrySoviBluemoon":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Bluemoon].ProdutoSovi = (byte)num;
                    break;
                case "EntrySoviLagunitas":
                    num = Math.Max(0, Math.Min(num, 100));
                    ((Entry)sender).Text = num.ToString();
                    SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Lagunitas].ProdutoSovi = (byte)num;
                    break;
            }

            // Atualiza os dados de cent�metros com base no identificador da Entry e o �ndice
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i + 1;

                if (nomeDoInvocador == ("EntryBadden" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Badden].ProdutoCentimetros[i] = num;

                    // Atualize a UI, se necess�rio
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        EspacoBadden.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.Craft, ProdutosSovi.Badden).ToString();
                    });

                    break;
                }
                else if (nomeDoInvocador == ("EntryBluemoon" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Bluemoon].ProdutoCentimetros[i] = num;

                    // Atualize a UI, se necess�rio
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        EspacoBluemoon.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.Craft, ProdutosSovi.Bluemoon).ToString();
                    });

                    break;
                }
                else if (nomeDoInvocador == ("EntryLagunitas" + indiceReal.ToString()))
                {
                    SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Lagunitas].ProdutoCentimetros[i] = num;

                    // Atualize a UI, se necess�rio
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        EspacoLagunitas.Text = SharedSoviInfos.GetEspacoCategoria(PagesSovi.Craft, ProdutosSovi.Lagunitas).ToString();
                    });

                    break;
                }
            }
            SharedSoviInfos.Save();
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
        SharedSoviInfos.Pages = SharedSoviInfos.Load();

        EntryAllCraft.Text = SharedSoviInfos.Pages[PageID].TotalCentimetros.ToString();
        EntryCraft.Text = SharedSoviInfos.Pages[PageID].PortfolioCentimetros.ToString();

        EntrySoviBadden.Text = SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Badden].ProdutoSovi.ToString();
        EntrySoviBluemoon.Text = SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Bluemoon].ProdutoSovi.ToString();
        EntrySoviLagunitas.Text = SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Lagunitas].ProdutoSovi.ToString();



        // BADDEN BADDEN
        Entry[] entry = { EntryBadden1, EntryBadden2, EntryBadden3, EntryBadden4, EntryBadden5, EntryBadden6,
                                EntryBadden7, EntryBadden8, EntryBadden9 };

        for (int i = 0; i < entry.Length; i++)
        {
            Entry entry2 = entry[i];
            entry2.Text = SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Badden].ProdutoCentimetros[i].ToString();
            // Fa�a algo com o objeto Entry na posi��o i
        }

        // BLUE MOON
        entry = new Entry[] { EntryBluemoon1, EntryBluemoon2, EntryBluemoon3, EntryBluemoon4, EntryBluemoon5, EntryBluemoon6,
                                EntryBluemoon7, EntryBluemoon8, EntryBluemoon9 };

        for (int i = 0; i < entry.Length; i++)
        {
            Entry entry2 = entry[i];
            entry2.Text = SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Bluemoon].ProdutoCentimetros[i].ToString();
            // Fa�a algo com o objeto Entry na posi��o i
        }

        // LAGUNITAS
        entry = new Entry[] { EntryLagunitas1, EntryLagunitas2, EntryLagunitas3, EntryLagunitas4, EntryLagunitas5, EntryLagunitas6,
                                EntryLagunitas7, EntryLagunitas8, EntryLagunitas9 };

        for (int i = 0; i < entry.Length; i++)
        {
            Entry entry2 = entry[i];
            entry2.Text = SharedSoviInfos.Pages[PageID].Produtos[(int)ProdutosSovi.Lagunitas].ProdutoCentimetros[i].ToString();
            // Fa�a algo com o objeto Entry na posi��o i
        }
    }
}
