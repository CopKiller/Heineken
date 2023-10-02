using AplicativoPromotor.Pages.Properties.SubPages;
using AplicativoPromotor.Produtos;
using Microsoft.Maui.Controls;

namespace AplicativoPromotor.Pages
{
    public partial class EconomyPage : ContentPage
    {
        private List<Produto> economyPageItems; // Substitua com o seu tipo de item

        public EconomyPage()
        {
            InitializeComponent();

            // Carregue a lista original de itens da p�gina Craft
            economyPageItems = new Economy().Items;

            // Configure a ListView com a lista original
            ItensListView.ItemsSource = economyPageItems;

            // Assine o evento TextChanged
            SearchEntry.TextChanged += OnSearchTextChanged;
        }

        private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = e.NewTextValue;

            // Aguarde um curto atraso antes de iniciar a pesquisa
            await Task.Delay(500); // Aguarde meio segundo (500 ms)

            // Obtenha o texto atual da caixa de pesquisa
            string currentSearchTerm = SearchEntry.Text;

            // Verifique se o texto n�o mudou desde o atraso
            if (searchTerm == currentSearchTerm)
            {
                // Realize a pesquisa
                var searchResults = economyPageItems
                    .Where(item => item.name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Atualize o ListView com os resultados da pesquisa
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ItensListView.ItemsSource = searchResults;
                });
            }
        }
    }
}
