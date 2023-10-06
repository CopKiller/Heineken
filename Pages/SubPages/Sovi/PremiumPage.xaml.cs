
namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class PremiumPage : ContentPage
{
    //private enum SearchTypes
    //{
    //    [Display(Name = "Nome")]
    //    Nome = 0,

    //    [Display(Name = "EAN")]
    //    EAN,

    //    [Display(Name = "Descri��o")]
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
                // N�o � um n�mero v�lido, ent�o voc� pode tomar alguma a��o aqui, como limpar o texto.
                ((Entry)sender).Text = "";
            }
        }
    }
}
