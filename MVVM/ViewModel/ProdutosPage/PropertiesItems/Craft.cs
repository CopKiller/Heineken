using AplicativoPromotor.MVVM.Model.ProdutosPage;
using AplicativoPromotor.MVVM.ViewModel.ProdutosPage.Produtos.Craft;

namespace AplicativoPromotor.MVVM.ViewModel.ProdutosPage.PropertiesItems
{
    public class Craft : Properties
    {
        private List<ProductModel> items; // Alteramos para uma propriedade privada

        public List<ProductModel> Items // Propriedade pública para acessar a lista
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged(nameof(Items)); // Notificar quando a propriedade Items é alterada
                }
            }
        }

        public Craft()
        {

            Items = new List<ProductModel>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Badden().GetProdutos());
            Items.AddRange(new Lagunitas().GetProdutos());
            Items.AddRange(new Bluemoon().GetProdutos());
        }
    }
}
