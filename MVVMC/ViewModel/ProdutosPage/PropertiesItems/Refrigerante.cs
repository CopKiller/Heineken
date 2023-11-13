using AplicativoPromotor.MVVMC.Model.ProdutosPage;
using AplicativoPromotor.MVVMC.ViewModel;
using AplicativoPromotor.MVVMC.ViewModel.ProdutosPage.Produtos.Refrigerante;

namespace AplicativoPromotor.MVVMC.ViewModel.ProdutosPage.PropertiesItems
{
    public class Refrigerante : Properties
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

        public Refrigerante()
        {

            Items = new List<ProductModel>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Fys().GetProdutos());
        }
    }
}
