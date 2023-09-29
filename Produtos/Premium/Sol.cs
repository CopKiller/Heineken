using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Sol
    {
        public List<Produto> items = new List<Produto>();
        public Sol()
        {
            items.Add(new Produto { name = "Sol 330ml Pilsen", id = 78934115, desc = "Cerveja do tipo Pilsen", foto = "sol330.png" });

        }
    }
}
