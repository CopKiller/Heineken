using AplicativoPromotor.MVVM.Model.ProdutosPage;
using AplicativoPromotor.MVVM.ViewModel;
using AplicativoPromotor.MVVM.ViewModel.ProdutosPage.Produtos.Premium;

namespace AplicativoPromotor.MVVM.ViewModel.ProdutosPage.PropertiesItems
{
    public class Premium : Properties
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

        public Premium()
        {

            Items = new List<ProductModel>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Heineken().GetProdutos());
            items.AddRange(new Eisenbahn().GetProdutos());
            items.AddRange(new Sol().GetProdutos());
        }
    }
}
