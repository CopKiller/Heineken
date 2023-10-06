using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Lagunitas : Produtos
    {
        public Lagunitas() 
        {
            AddProduto(new Item { Name = "Lagunitas 355ml Ipa", 
                                    Id = 7896045506187,
                                    Desc = "Cerveja sabor Maracuja", 
                                    Foto = "lagunitasipa355.png" });

            AddProduto(new Item { Name = "Lagunitas 350ml Ipa", 
                                    Id = 7896045506682, 
                                    Desc = "Cerveja sabor Maracuja" , 
                                    Foto = "lagunitasipa350.png" });
        }
    }
}
