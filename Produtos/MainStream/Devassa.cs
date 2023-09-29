using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.MainStream
{
    public class Devassa
    {
        public List<Produto> items = new List<Produto>();
        public Devassa()
        {
            items.Add(new Produto { name = "Devassa 269ml Puro Malte", id = 7898904771545, desc = "Cerveja do tipo Puro Malte", foto = "devassa269.png" });
            items.Add(new Produto { name = "Devassa 350ml Puro Malte", id = 7898904771613, desc = "Cerveja do tipo Puro Malte", foto = "devassa350.png" });

        }
    }
}
