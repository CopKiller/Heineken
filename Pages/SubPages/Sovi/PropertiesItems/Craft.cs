using AplicativoPromotor.Produtos;
using AplicativoPromotor.Produtos.Craft;
using AplicativoPromotor.Pages.PropertiesPages;

namespace AplicativoPromotor.Pages.SubPages.Sovi.PropertiesItems
{
    public class Craft : Properties
    {
        private List<Item> items; // Alteramos para uma propriedade privada

        public List<Item> Items // Propriedade pública para acessar a lista
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

            Items = new List<Item>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Badden().GetProdutos());
            Items.AddRange(new Lagunitas().GetProdutos());
            Items.AddRange(new Bluemoon().GetProdutos());
        }
    }
}
