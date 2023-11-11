using AplicativoPromotor.Model;
using AplicativoPromotor.ViewModel.ProdutosPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Craft
{
    public class Lagunitas : ProductViewModel
    {
        public Lagunitas() 
        {
            AddProduto(new ProductModel
            { Name = "Lagunitas 355ml Ipa", 
                                    Id = 7896045506187,
                                    Desc = "Cerveja sabor Maracuja", 
                                    Foto = "lagunitasipa355.png" });

            AddProduto(new ProductModel
            { Name = "Lagunitas 350ml Ipa", 
                                    Id = 7896045506682, 
                                    Desc = "Cerveja sabor Maracuja" , 
                                    Foto = "lagunitasipa350.png" });
        }
    }
}
