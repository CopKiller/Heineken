using AplicativoPromotor.Pages.Properties.Subtitles;

namespace AplicativoPromotor.Pages;

public partial class EconomyPage : ContentPage
{
    public EconomyPage()
    {
        InitializeComponent();

        var economyPage = new Economy().Items;

        ItensListView.ItemsSource = economyPage;
    }
}