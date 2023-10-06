using AplicativoPromotor.Pages.PropertiesPages;
using AplicativoPromotor.Produtos;
using AplicativoPromotor.Produtos.Economy;

namespace AplicativoPromotor.Pages.SubPages.Sovi.PropertiesItems
{
    public class Economy : Properties
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

        public Economy()
        {

            Items = new List<Item>();

            // Atribua os itens diretamente à propriedade Items
            Items.AddRange(new Schin().GetProdutos());
        }
    }
}
