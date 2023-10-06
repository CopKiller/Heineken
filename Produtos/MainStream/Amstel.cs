using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.MainStream
{
    public class Amstel : Produtos
    {
        public Amstel()
        {
            AddProduto(new Item { Name = "Amstel 269ml Puro Malte", Id = 7896045505319, Desc = "Cerveja do tipo Puro Malte", Foto = "amstel269.png" });
            AddProduto(new Item { Name = "Amstel 350ml Puro Malte", Id = 7896045506941, Desc = "Cerveja do tipo Puro Malte", Foto = "amstel350.png" });

        }
    }
}
