using AplicativoPromotor.Pages.ToolsPages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;

namespace AplicativoPromotor.Pages.SubPages.Sovi.Resumo;
public partial class ResumoPage : ContentPage
{
    
    public ResumoPage()
    {
        InitializeComponent();

        RefreshResumoData();
    }

    private void SalvarComoPDF_Clicked(object sender, EventArgs e)
    {
        // Crie um documento PDF
        PdfDocument document = new PdfDocument();

        // Crie uma página no documento
        PdfPage page = document.Pages.Add();

        // Obtenha um objeto PDFGraphics para desenhar na página
        PdfGraphics graphics = page.Graphics;

        // Obtenha a representação visual da página XAML
        var xamlPage = Content;

        // Converta a página XAML em uma imagem
        var imageStream = DependencyService.Get<IXamlToImage>().ConvertToImage(xamlPage);

        // Desenhe a imagem na página PDF
        if (imageStream != null)
        {
            PdfBitmap image = new PdfBitmap(imageStream);
            graphics.DrawImage(image, 0, 0, (float)page.Size.Width, (float)page.Size.Height);
        }

        // Salve o documento em um arquivo PDF
        using (Stream pdfStream = DependencyService.Get<ISavePDF>().SavePDF(document))
        {
            pdfStream.Position = 0;
            pdfStream.CopyTo(File.OpenWrite("meu_documento.pdf"));
        }

        // Feche o documento
        document.Close();
    }

    public interface IXamlToImage
    {
        Stream ConvertToImage(View view);
    }

    public interface ISavePDF
    {
        Stream SavePDF(PdfDocument document);
    }

    //private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    //{

    //    // Obtém o novo texto e o identificador da Entry que acionou o evento
    //    //string newTextValue = e.NewTextValue;
    //    //string nomeDoInvocador = ((Entry)sender).ClassId;
    //}

    // --> Botão que inicia a leitura do PDF de Sovi
    //private async void OnButtonClicked(object sender, EventArgs e)
    //{
    //}

    private Task RefreshResumoData()
    {
        // Obtenha a data atual e atualize o controle
        DateTime currentDate = DateTime.Now;
        DataAtual.Text += currentDate.ToString("dd/MM/yyyy");

        
        return Task.CompletedTask;
    }
}
