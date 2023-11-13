using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.MVVMC.Model.ProdutosPage;
using AplicativoPromotor.MVVMC.ViewModel.ProdutosPage;

namespace AplicativoPromotor.MVVMC.ViewModel.ProdutosPage.Produtos.Economy
{
    public class Schin : ProductViewModel
    {
        public Schin()
        {
            AddProduto(new ProductModel { Name = "Schin 350ml Puro Malte", Id = 78934115, Desc = "Cerveja do tipo Puro Malte", Foto = "schin350.png" });

        }
    }
}
