using System.ComponentModel;
using System.Reflection;

namespace AplicativoPromotor.Pages.ToolsPages;

public partial class PdfViewerPage : ContentPage
{
    public PdfViewerPage()
    {
        InitializeComponent();
    }
}

class PdfViewerView : INotifyPropertyChanged
{
    private Stream? m_pdfDocumentStream;

    /// <summary>
    /// An event to detect the change in the value of a property.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// The PDF document stream that is loaded into the instance of the PDF viewer. 
    /// </summary>
    public Stream PdfDocumentStream
    {
        get
        {
            return m_pdfDocumentStream;
        }
        set
        {
            m_pdfDocumentStream = value;
            OnPropertyChanged("PdfDocumentStream");
        }
    }

    /// <summary>
    /// Constructor of the view model class
    /// </summary>
    public PdfViewerView()
    {
        //Accessing the PDF document that is added as embedded resource as stream.
        m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AplicativoPromotor.Resources.Assets.sovimetas.pdf");
    }

    public void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}