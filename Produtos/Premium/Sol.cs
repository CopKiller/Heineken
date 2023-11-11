using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.Model;
using AplicativoPromotor.ViewModel.ProdutosPage;

namespace AplicativoPromotor.Produtos.Premium
{
    public class Sol : ProductViewModel
    {
        public Sol()
        {
            AddProduto(new ProductModel { Name = "Sol 330ml Pilsen", Id = 78934115, Desc = "Cerveja do tipo Pilsen", Foto = "sol330.png" });

        }
    }
}
