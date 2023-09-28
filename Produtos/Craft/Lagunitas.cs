using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Lagunitas
    {
        public List<Produto> items = new List<Produto>();
        public Lagunitas() 
        {
            items.Add(new Produto { name = "Lagunitas 355ml Ipa", 
                                    id = 7896045506187,
                                    desc = "Cerveja sabor Maracuja", 
                                    foto = "lagunitasipa355.png" });

            items.Add(new Produto { name = "Lagunitas 350ml Ipa", 
                                    id = 7896045506682, 
                                    desc = "Cerveja sabor Maracuja" , 
                                    foto = "lagunitasipa350.png" });
        }
    }
}
