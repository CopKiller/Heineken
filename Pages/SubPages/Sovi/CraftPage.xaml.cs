
using System.Diagnostics;

namespace AplicativoPromotor.Pages.SubPages.Sovi;
public partial class CraftPage : ContentPage
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

    public CraftPage()
    {
        InitializeComponent();

        // Assine o evento TextChanged
        //SearchEntry.TextChanged += OnSearchTextChanged;
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
            return; // N�o faz nada se o texto estiver vazio
        }

        if (!double.TryParse(e.NewTextValue, out var num))
        {
            ((Entry)sender).Text = ""; // Limpa o texto se n�o for um n�mero v�lido
        }
        else
        {
            var nomeDoInvocador = ((Entry)sender).ClassId;

            switch (nomeDoInvocador)
            {
                case "EntrySoviBadden":
                    {
                        num = Math.Max(0, Math.Min(num, 100)); // Limita o n�mero entre 0 e 100
                        ((Entry)sender).Text = num.ToString();
                        break;
                    }
                    // Adicione mais casos aqui, se necess�rio
            }
        }
    }
}
