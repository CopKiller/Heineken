
namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class PremiumPage : ContentPage
{
    //private enum SearchTypes
    //{
    //    [Display(Name = "Nome")]
    //    Nome = 0,

    //    [Display(Name = "EAN")]
    //    EAN,

    //    [Display(Name = "Descrição")]
    //    Desc
    //}

    //private List<Item> craftPageItems; // Substitua com o seu tipo de item
    //private int searchType = (int)SearchTypes.Nome;

    public PremiumPage()
    {
        InitializeComponent();

        // Assine o evento TextChanged
        //SearchEntry.TextChanged += OnSearchTextChanged;
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            if (!double.TryParse(e.NewTextValue, out _))
            {
                // Não é um número válido, então você pode tomar alguma ação aqui, como limpar o texto.
                ((Entry)sender).Text = "";
            }
        }
    }
}
