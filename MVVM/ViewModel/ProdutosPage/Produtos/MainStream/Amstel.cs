using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.MVVM.Model.ProdutosPage;
using AplicativoPromotor.MVVM.ViewModel.ProdutosPage;

namespace AplicativoPromotor.MVVM.ViewModel.ProdutosPage.Produtos.MainStream
{
    public class Amstel : ProductViewModel
    {
        public Amstel()
        {
            AddProduto(new ProductModel { Name = "Amstel 269ml Puro Malte", Id = 7896045505319, Desc = "Cerveja do tipo Puro Malte", Foto = "amstel269.png" });
            AddProduto(new ProductModel { Name = "Amstel 350ml Puro Malte", Id = 7896045506941, Desc = "Cerveja do tipo Puro Malte", Foto = "amstel350.png" });

        }
    }
}
