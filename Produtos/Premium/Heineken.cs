using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Heineken
    {
        public List<Produto> items = new List<Produto>();
        public Heineken()
        {
            items.Add(new Produto { name = "Heineken 250ml Lager", id = 78935495, desc = "Cerveja Puro malte do tipo Lager", foto = "heineken250.png" });
            items.Add(new Produto { name = "Heineken 330ml Lager", id = 78936683, desc = "Cerveja Puro malte do tipo Lager", foto = "heineken330.png" });
            items.Add(new Produto { name = "Heineken 330ml 0.0%", id = 7896045506040, desc = "Cerveja Puro malte do tipo Zero Alcool", foto = "heinekenzero330.png" });
            items.Add(new Produto { name = "Heineken 269ml Lager", id = 7896045506590, desc = "Cerveja Puro malte do tipo Lager", foto = "heineken269.png" });
            items.Add(new Produto { name = "Heineken 269ml 0.0%", id = 7896045506859, desc = "Cerveja Puro malte do tipo Zero Alcool", foto = "heinekenzero269.png" });
            items.Add(new Produto { name = "Heineken 350ml Sleek Lager", id = 7896045506880, desc = "Cerveja Puro malte do tipo Lager", foto = "heineken350.png" });
            items.Add(new Produto { name = "Heineken 350ml Sleek 0.0%", id = 7896045506910, desc = "Cerveja Puro malte do tipo Zero Alcool", foto = "heinekenzero350.png" });
            items.Add(new Produto { name = "Heineken 600ml Lager", id = 78905498, desc = "Cerveja Puro malte do tipo Lager", foto = "heineken600.png" });
            items.Add(new Produto { name = "Heineken 5L Chopp", id = 7890322860009, desc = "Cerveja Puro malte do tipo Lager", foto = "heineken5000.png" });
        }
    }
}
