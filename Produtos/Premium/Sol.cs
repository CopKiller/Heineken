using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Sol : Produtos
    {
        public Sol()
        {
            AddProduto(new Item { Name = "Sol 330ml Pilsen", Id = 78934115, Desc = "Cerveja do tipo Pilsen", Foto = "sol330.png" });

        }
    }
}
