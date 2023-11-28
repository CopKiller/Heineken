using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.Pages.ToolsPages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Diagnostics;

namespace AplicativoPromotor.Pages.SubPages.Sovi.Resumo;
public partial class ResumoPage : ContentPage
{
    private Dictionary<PagesSovi, double> carouselHeights = new Dictionary<PagesSovi, double>();

    public ResumoPage()
    {
        InitializeComponent();
        InitializeCarouselHeights();
    }

    private void InitializeCarouselHeights()
    {
        foreach (PagesSovi pageType in Enum.GetValues(typeof(PagesSovi)))
        {
            carouselHeights[pageType] = 0;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SetCarouselHeights();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        UpdateCarouselHeights();
    }

    private void SetCarouselHeights()
    {
        foreach (PagesSovi pageType in Enum.GetValues(typeof(PagesSovi)))
        {
            double height = GetCarouselHeightForPageType(pageType);
            carouselHeights[pageType] = height;

            SetCarouselHeight(pageType, height);
        }
    }

    private double GetCarouselHeightForPageType(PagesSovi pageType)
    {
        switch (pageType)
        {
            case PagesSovi.Craft:
                return CarouselCraft.Height;
            case PagesSovi.Premium:
                return CarouselPremium.Height;
            case PagesSovi.MainStream:
                return CarouselMainStream.Height;
            // Adicione mais casos conforme necess�rio
            default:
                return 0;
        }
    }

    private void SetCarouselHeight(PagesSovi pageType, double height)
    {
        switch (pageType)
        {
            case PagesSovi.Craft:
                CarouselCraft.HeightRequest = height;
                break;
            case PagesSovi.Premium:
                CarouselPremium.HeightRequest = height;
                break;
            case PagesSovi.MainStream:
                CarouselMainStream.HeightRequest = height;
                break;
                // Adicione mais casos conforme necess�rio
        }
    }

    private void UpdateCarouselHeights()
    {
        foreach (PagesSovi pageType in Enum.GetValues(typeof(PagesSovi)))
        {
            carouselHeights[pageType] = GetCarouselHeightForPageType(pageType);
        }
    }

    // Outros m�todos e propriedades
}


//private void SalvarComoPDF_Clicked(object sender, EventArgs e)
//{
//    // Crie um documento PDF
//    PdfDocument document = new PdfDocument();

//    // Crie uma p�gina no documento
//    PdfPage page = document.Pages.Add();

//    // Obtenha um objeto PDFGraphics para desenhar na p�gina
//    PdfGraphics graphics = page.Graphics;

//    // Obtenha a representa��o visual da p�gina XAML
//    var xamlPage = Content;

//    // Converta a p�gina XAML em uma imagem
//    var imageStream = DependencyService.Get<IXamlToImage>().ConvertToImage(xamlPage);

//    // Desenhe a imagem na p�gina PDF
//    if (imageStream != null)
//    {
//        PdfBitmap image = new PdfBitmap(imageStream);
//        graphics.DrawImage(image, 0, 0, (float)page.Size.Width, (float)page.Size.Height);
//    }

//    // Salve o documento em um arquivo PDF
//    using (Stream pdfStream = DependencyService.Get<ISavePDF>().SavePDF(document))
//    {
//        pdfStream.Position = 0;
//        pdfStream.CopyTo(File.OpenWrite("meu_documento.pdf"));
//    }

//    // Feche o documento
//    document.Close();
//}

//public interface IXamlToImage
//{
//    Stream ConvertToImage(View view);
//}

//public interface ISavePDF
//{
//    Stream SavePDF(PdfDocument document);
//}

//private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
//{

//    // Obt�m o novo texto e o identificador da Entry que acionou o evento
//    //string newTextValue = e.NewTextValue;
//    //string nomeDoInvocador = ((Entry)sender).ClassId;
//}

// --> Bot�o que inicia a leitura do PDF de Sovi
//private async void OnButtonClicked(object sender, EventArgs e)
//{
//}

//private Task RefreshResumoData()
//    {
//        // Obtenha a data atual e atualize o controle
//        //DateTime currentDate = DateTime.Now;
//        //DataAtual.Text += currentDate.ToString("dd/MM/yyyy");



//        return Task.CompletedTask;
//    }
//}
