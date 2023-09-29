namespace AplicativoPromotor.Pages;

using AplicativoPromotor.Pages.Properties.Subtitles;

public partial class PremiumPage : ContentPage
{
    public PremiumPage()
    {
        InitializeComponent();

        var premiumPage = new Premium().Items;

        ItensListView.ItemsSource = premiumPage;
    }
}