using AplicativoPromotor.Pages.PropertiesPages;
using AplicativoPromotor.Produtos;
using AplicativoPromotor.Produtos.MainStream;

namespace AplicativoPromotor.Pages.SubPages.Produtos.PropertiesItems
{
    public class MainStream : Properties
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

        public MainStream()
        {

            Items = new List<Item>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Amstel().GetProdutos());
            items.AddRange(new Devassa().GetProdutos());
        }
    }
}
