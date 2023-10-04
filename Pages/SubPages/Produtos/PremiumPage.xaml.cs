using AplicativoPromotor.Pages.SubPages.Produtos.PropertiesItems;
using AplicativoPromotor.Produtos;
using Microsoft.Maui.Controls;
using System.ComponentModel.DataAnnotations;

namespace AplicativoPromotor.Pages.SubPages.Produtos;

public partial class PremiumPage : ContentPage
{
    private enum SearchTypes
    {
        [Display(Name = "Nome")]
        Nome = 0,

        [Display(Name = "EAN")]
        EAN,

        [Display(Name = "Descrição")]
        Desc
    }

    private List<Produto> premiumPageItems; // Substitua com o seu tipo de item
    private int searchType = (int)SearchTypes.Nome;

    public PremiumPage()
    {
        InitializeComponent();

        // Carregue a lista original de itens da página Craft
        premiumPageItems = new Premium().Items;

        // Configure a ListView com a lista original
        ItensListView.ItemsSource = premiumPageItems;

        // Inicialize um índice padrão de pesquisa na busca
        SearchTypePicker.SelectedIndex = (int)SearchTypes.Nome;

        // Assine o evento TextChanged
        SearchEntry.TextChanged += OnSearchTextChanged;
    }

    private void OnSearchTypeSelectedIndexChanged(object sender, EventArgs e)
    {
        searchType = SearchTypePicker.SelectedIndex;

        // Chame OnSearchTextChanged para atualizar a lista com base no novo tipo de pesquisa
        OnSearchTextChanged(sender, new TextChangedEventArgs(SearchEntry.Text, SearchEntry.Text));
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchTerm = e.NewTextValue;

        // Aguarde um curto atraso antes de iniciar a pesquisa
        await Task.Delay(500); // Aguarde meio segundo (500 ms)

        // Obtenha o texto atual da caixa de pesquisa
        string currentSearchTerm = SearchEntry.Text;

        // Verifique se o texto não mudou desde o atraso
        if (searchTerm == currentSearchTerm && currentSearchTerm != null)
        {
            // Realize a pesquisa com base no tipo selecionado
            List<Produto> searchResults = new List<Produto>();

            switch (searchType)
            {
                case (int)SearchTypes.Nome:
                    searchResults = premiumPageItems
                        .Where(item => item.name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case (int)SearchTypes.EAN:
                    searchResults = premiumPageItems
                        .Where(item => item.id.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case (int)SearchTypes.Desc:
                    searchResults = premiumPageItems
                        .Where(item => item.desc.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                default:
                    break;
            }

            // Atualize o ListView com os resultados da pesquisa
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ItensListView.ItemsSource = searchResults;
            });
        }
    }
}