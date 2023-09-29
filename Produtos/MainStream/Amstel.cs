using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.MainStream
{
    public class Amstel
    {
        public List<Produto> items = new List<Produto>();
        public Amstel()
        {
            items.Add(new Produto { name = "Amstel 269ml Puro Malte", id = 7896045505319, desc = "Cerveja do tipo Puro Malte", foto = "amstel269.png" });
            items.Add(new Produto { name = "Amstel 350ml Puro Malte", id = 7896045506941, desc = "Cerveja do tipo Puro Malte", foto = "amstel350.png" });

        }
    }
}
