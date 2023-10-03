using AplicativoPromotor.Pages.PropertiesPage;
using AplicativoPromotor.Produtos;
using AplicativoPromotor.Produtos.Craft;

namespace AplicativoPromotor.Pages.SubPages.Produtos.Interface
{
    public class Craft : Properties
    {
        private List<Produto> items; // Alteramos para uma propriedade privada

        public List<Produto> Items // Propriedade pública para acessar a lista
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

            Items = new List<Produto>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Badden().items);
            Items.AddRange(new Lagunitas().items);
            Items.AddRange(new Bluemoon().items);
        }
    }
}
