using AplicativoPromotor.Pages.PropertiesPage;
using AplicativoPromotor.Produtos;
using AplicativoPromotor.Produtos.Premium;

namespace AplicativoPromotor.Pages.SubPages.Sovi.Interface
{
    public class Premium : Properties
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

        public Premium()
        {

            Items = new List<Produto>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Heineken().items);
            items.AddRange(new Eisenbahn().items);
            items.AddRange(new Sol().items);
        }
    }
}
