using AplicativoPromotor.MVVM.Model.ProdutosPage;
using AplicativoPromotor.MVVM.ViewModel.ProdutosPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVM.ViewModel.ProdutosPage.Produtos.Economy
{
    public class Glacial : ProductViewModel
    {
        public Glacial()
        {
            AddProduto(new ProductModel { Name = "Glacial 350ml Pilsen", Id = 78934115, Desc = "Cerveja do tipo Pilsen", Foto = "glacial350.png" });

        }
    }
}
