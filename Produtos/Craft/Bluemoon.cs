using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Bluemoon
    {
        public List<Produto> items = new List<Produto>();
        public Bluemoon()
        {
            items.Add(new Produto
            {
                name = "Bluemoon 355ml Belgian White",
                id = 7898235981033,
                desc = "Cerveja sabor Coentro & Casca de laranja",
                foto = "bluemoon355.png"
            });

            items.Add(new Produto
            {
                name = "Bluemoon 350ml Belgian White",
                id = 7896045506477,
                desc = "Cerveja sabor Coentro & Casca de laranja",
                foto = "bluemoon350.png"
            });
        }
    }
}
