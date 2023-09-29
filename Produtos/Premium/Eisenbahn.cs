using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Eisenbahn
    {
        public List<Produto> items = new List<Produto>();
        public Eisenbahn()
        {
            items.Add(new Produto { name = "Eisenbahn 350ml Pilsen", id = 7898367983790, desc = "Cerveja Puro malte do tipo Pilsen", foto = "eisenbahn350.png" });
            items.Add(new Produto { name = "Eisenbahn 355ml Pilsen", id = 7898367980010, desc = "Cerveja Puro malte do tipo Pilsen", foto = "eisenbahn355.png" });
            items.Add(new Produto { name = "Eisenbahn Unfiltered 350ml Pilsen", id = 7898367984377, desc = "Cerveja Puro malte do tipo Pilsen", foto = "eisenbahnunfiltered350.png" });
            items.Add(new Produto { name = "Eisenbahn Unfiltered 355ml Pilsen", id = 7898367984346, desc = "Cerveja Puro malte do tipo Pilsen", foto = "eisenbahnunfiltered355.png" });
        }
    }
}
