using AplicativoPromotor.Pages.Properties.Subtitles;

namespace AplicativoPromotor.Pages;

public partial class MainStreamPage : ContentPage
{
    public MainStreamPage()
    {
        InitializeComponent();

        var mainstreamPage = new MainStream().Items;

        ItensListView.ItemsSource = mainstreamPage;
    }
}