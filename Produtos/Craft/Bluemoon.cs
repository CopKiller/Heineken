using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Bluemoon : Produtos
    {
        public Bluemoon()
        {
            AddProduto(new Item
            {
                Name = "Bluemoon 355ml Belgian White",
                Id = 7898235981033,
                Desc = "Cerveja sabor Coentro & Casca de laranja",
                Foto = "bluemoon355.png"
            });

            AddProduto(new Item
            {
                Name = "Bluemoon 350ml Belgian White",
                Id = 7896045506477,
                Desc = "Cerveja sabor Coentro & Casca de laranja",
                Foto = "bluemoon350.png"
            });
        }
    }
}
