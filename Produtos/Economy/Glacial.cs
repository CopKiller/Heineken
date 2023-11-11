using AplicativoPromotor.Model;
using AplicativoPromotor.ViewModel.ProdutosPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Economy
{
    public class Glacial : ProductViewModel
    {
        public Glacial()
        {
            AddProduto(new ProductModel { Name = "Glacial 350ml Pilsen", Id = 78934115, Desc = "Cerveja do tipo Pilsen", Foto = "glacial350.png" });

        }
    }
}
