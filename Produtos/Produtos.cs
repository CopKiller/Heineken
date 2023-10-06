using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos
{
    public class Produtos
    {
        private List<Item> items = new List<Item>();

        public Produtos() 
        {
            items = new List<Item>();
        }

        public void AddProduto(Item produto)
        {
            this.items.Add(produto);
        }

        public List<Item> GetProdutos()
        {
            return this.items;
        }
    }
}
