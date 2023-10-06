using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Badden : Produtos
    {
        public Badden() 
        {
            AddProduto(new Item { Name = "Badden Badden 600ml Ipa", Id = 7898230715558, Desc = "Cerveja sabor Maracuja", Foto = "baddenipa600.png" });
            AddProduto(new Item { Name = "Badden Badden 600ml Golden", Id = 7898230715077, Desc = "Cerveja sabor Canela", Foto = "baddengolden600.png" });
            AddProduto(new Item { Name = "Badden Badden 600ml Witbier", Id = 7898230715213, Desc = "Cerveja sabor Coentro & casca de Laranja", Foto = "baddenwitbier600.png" });
            AddProduto(new Item { Name = "Badden Badden 600ml Crystal", Id = 7898230710102, Desc = "Cerveja Pilsen Puro Malte", Foto = "baddencrystal600.png" });

            AddProduto(new Item { Name = "Badden Badden 350ml Ipa", Id = 7898230716654, Desc = "Cerveja sabor Maracuja", Foto = "baddenipa350.png" });
            AddProduto(new Item { Name = "Badden Badden 350ml Golden", Id = 7898230716784, Desc = "Cerveja sabor Canela", Foto = "baddengolden350.png" });
            AddProduto(new Item { Name = "Badden Badden 350ml Witbier", Id = 7898230716630, Desc = "Cerveja sabor Coentro & casca de Laranja", Foto = "baddenwitbier350.png" });
            AddProduto(new Item { Name = "Badden Badden 350ml Crystal", Id = 7898230716616, Desc = "Cerveja Pilsen Puro Malte", Foto = "baddencrystal350.png" });
        }
    }
}
