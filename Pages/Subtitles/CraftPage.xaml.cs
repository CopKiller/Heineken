using AplicativoPromotor.Pages.Properties.Subtitles;

namespace AplicativoPromotor.Pages;

public partial class CraftPage : ContentPage
{
    public CraftPage()
    {
        InitializeComponent();

        var craftPage = new Craft().Items;

        ItensListView.ItemsSource = craftPage;
    }
}