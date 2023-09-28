using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Badden
    {
        public List<Produto> items = new List<Produto>();
        public Badden() 
        {
            items.Add(new Produto { name = "Badden Badden 600ml Ipa", id = 7898230715558, desc = "Cerveja sabor Maracuja", foto = "baddenipa600.png" });
            items.Add(new Produto { name = "Badden Badden 600ml Golden", id = 7898230715077, desc = "Cerveja sabor Canela", foto = "baddengolden600.png" });
            items.Add(new Produto { name = "Badden Badden 600ml Witbier", id = 7898230715213, desc = "Cerveja sabor Coentro & casca de Laranja", foto = "baddenwitbier600.png" });
            items.Add(new Produto { name = "Badden Badden 600ml Crystal", id = 7898230710102, desc = "Cerveja Pilsen Puro Malte", foto = "baddencrystal600.png" });

            items.Add(new Produto { name = "Badden Badden 350ml Ipa", id = 7898230716654, desc = "Cerveja sabor Maracuja", foto = "baddenipa350.png" });
            items.Add(new Produto { name = "Badden Badden 350ml Golden", id = 7898230716784, desc = "Cerveja sabor Canela", foto = "baddengolden350.png" });
            items.Add(new Produto { name = "Badden Badden 350ml Witbier", id = 7898230716630, desc = "Cerveja sabor Coentro & casca de Laranja", foto = "baddenwitbier350.png" });
            items.Add(new Produto { name = "Badden Badden 350ml Crystal", id = 7898230716616, desc = "Cerveja Pilsen Puro Malte", foto = "baddencrystal350.png" });
        }
    }
}
