using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Economy
{
    public class Schin
    {
        public List<Produto> items = new List<Produto>();
        public Schin()
        {
            items.Add(new Produto { name = "Schin 350ml Puro Malte", id = 78934115, desc = "Cerveja do tipo Puro Malte", foto = "schin350.png" });

        }
    }
}
