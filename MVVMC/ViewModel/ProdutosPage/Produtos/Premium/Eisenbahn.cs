using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.MVVMC.Model.ProdutosPage;
using AplicativoPromotor.MVVMC.ViewModel.ProdutosPage;

namespace AplicativoPromotor.MVVMC.ViewModel.ProdutosPage.Produtos.Premium
{
    public class Eisenbahn : ProductViewModel
    {
        public Eisenbahn()
        {
            AddProduto(new ProductModel { Name = "Eisenbahn 350ml Pilsen", Id = 7898367983790, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahn350.png" });
            AddProduto(new ProductModel { Name = "Eisenbahn 355ml Pilsen", Id = 7898367980010, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahn355.png" });
            AddProduto(new ProductModel { Name = "Eisenbahn Unfiltered 350ml Pilsen", Id = 7898367984377, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahnunfiltered350.png" });
            AddProduto(new ProductModel { Name = "Eisenbahn Unfiltered 355ml Pilsen", Id = 7898367984346, Desc = "Cerveja Puro malte do tipo Pilsen", Foto = "eisenbahnunfiltered355.png" });
        }
    }
}
