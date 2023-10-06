using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Eisenbahn : Produtos
    {
        public Eisenbahn()
        {
            AddProduto(new Item { Name = "Eisenbahn 350ml Pilsen", Id = 7898367983790, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahn350.png" });
            AddProduto(new Item { Name = "Eisenbahn 355ml Pilsen", Id = 7898367980010, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahn355.png" });
            AddProduto(new Item { Name = "Eisenbahn Unfiltered 350ml Pilsen", Id = 7898367984377, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahnunfiltered350.png" });
            AddProduto(new Item { Name = "Eisenbahn Unfiltered 355ml Pilsen", Id = 7898367984346, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahnunfiltered355.png" });
        }
    }
}
