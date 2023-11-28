using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.MVVM.Model.ProdutosPage;
using AplicativoPromotor.MVVM.ViewModel.ProdutosPage;

namespace AplicativoPromotor.MVVM.ViewModel.ProdutosPage.Produtos.MainStream
{
    public class Devassa : ProductViewModel
    {
        public Devassa()
        {
            AddProduto(new ProductModel { Name = "Devassa 269ml Puro Malte", Id = 7898904771545, Desc = "Cerveja do tipo Puro Malte", Foto = "devassa269.png" });
            AddProduto(new ProductModel { Name = "Devassa 350ml Puro Malte", Id = 7898904771613, Desc = "Cerveja do tipo Puro Malte", Foto = "devassa350.png" });

        }
    }
}
