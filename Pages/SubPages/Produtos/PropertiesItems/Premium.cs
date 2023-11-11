using AplicativoPromotor.Model;
using AplicativoPromotor.Pages.PropertiesPages;
using AplicativoPromotor.Produtos.Premium;

namespace AplicativoPromotor.Pages.SubPages.Produtos.PropertiesItems
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
