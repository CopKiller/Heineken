using AplicativoPromotor.Pages.Properties.Subtitles;

namespace AplicativoPromotor.Pages;

public partial class RefrigerantePage : ContentPage
{
    public RefrigerantePage()
    {
        InitializeComponent();

        var refrigerantePage = new Refrigerante().Items;

        ItensListView.ItemsSource = refrigerantePage;
    }
}