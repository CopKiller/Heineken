using AplicativoPromotor.MVVM.Model.ProdutosPage;
using AplicativoPromotor.MVVM.ViewModel.ProdutosPage.PropertiesItems;
using Microsoft.Maui.Controls;
using System.ComponentModel.DataAnnotations;

namespace AplicativoPromotor.MVVM.View.ProductsPage;
public partial class CraftPage : ContentPage
{
    private enum SearchTypes
    {
        [Display(Name = "Nome")]
        Nome = 0,

        [Display(Name = "EAN")]
        EAN,

        [Display(Name = "Descri��o")]
        Desc
    }

    private List<ProductModel> craftPageItems; // Substitua com o seu tipo de item
    private int searchType = (int)SearchTypes.Nome;

    public CraftPage()
    {
        InitializeComponent();

        // Carregue a lista original de itens da p�gina Craft
        craftPageItems = new Craft().Items;

        // Configure a ListView com a lista original
        ItensListView.ItemsSource = craftPageItems;

        // Inicialize um �ndice padr�o de pesquisa na busca
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

        // Verifique se o texto n�o mudou desde o atraso
        if (searchTerm == currentSearchTerm && currentSearchTerm != null)
        {
            // Realize a pesquisa com base no tipo selecionado
            List<ProductModel> searchResults = new List<ProductModel>();

            switch (searchType)
            {
                case (int)SearchTypes.Nome:
                    searchResults = craftPageItems
                        .Where(item => item.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case (int)SearchTypes.EAN:
                    searchResults = craftPageItems
                        .Where(item => item.Id.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case (int)SearchTypes.Desc:
                    searchResults = craftPageItems
                        .Where(item => item.Desc.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
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
