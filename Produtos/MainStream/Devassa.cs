using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.MainStream
{
    public class Devassa : Produtos
    {
        public Devassa()
        {
            AddProduto(new Item { Name = "Devassa 269ml Puro Malte", Id = 7898904771545, Desc = "Cerveja do tipo Puro Malte", Foto = "devassa269.png" });
            AddProduto(new Item { Name = "Devassa 350ml Puro Malte", Id = 7898904771613, Desc = "Cerveja do tipo Puro Malte", Foto = "devassa350.png" });

        }
    }
}
