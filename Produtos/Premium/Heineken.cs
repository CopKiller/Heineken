using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Heineken : Produtos
    {
        public Heineken()
        {
            AddProduto(new Item { Name = "Heineken 250ml Lager", Id = 78935495, Desc = "Cerveja Puro malte do tipo Lager", Foto = "heineken250.png" });
            AddProduto(new Item { Name = "Heineken 330ml Lager", Id = 78936683, Desc = "Cerveja Puro malte do tipo Lager", Foto = "heineken330.png" });
            AddProduto(new Item { Name = "Heineken 330ml 0.0%", Id = 7896045506040, Desc = "Cerveja Puro malte do tipo Zero Alcool", Foto = "heinekenzero330.png" });
            AddProduto(new Item { Name = "Heineken 269ml Lager", Id = 7896045506590, Desc = "Cerveja Puro malte do tipo Lager", Foto = "heineken269.png" });
            AddProduto(new Item { Name = "Heineken 269ml 0.0%", Id = 7896045506859, Desc = "Cerveja Puro malte do tipo Zero Alcool", Foto = "heinekenzero269.png" });
            AddProduto(new Item { Name = "Heineken 350ml Sleek Lager", Id = 7896045506880, Desc = "Cerveja Puro malte do tipo Lager", Foto = "heineken350.png" });
            AddProduto(new Item { Name = "Heineken 350ml Sleek 0.0%", Id = 7896045506910, Desc = "Cerveja Puro malte do tipo Zero Alcool", Foto = "heinekenzero350.png" });
            AddProduto(new Item { Name = "Heineken 600ml Lager", Id = 78905498, Desc = "Cerveja Puro malte do tipo Lager", Foto = "heineken600.png" });
            AddProduto(new Item { Name = "Heineken 5L Chopp", Id = 7890322860009, Desc = "Cerveja Puro malte do tipo Lager", Foto = "heineken5000.png" });
        }
    }
}
