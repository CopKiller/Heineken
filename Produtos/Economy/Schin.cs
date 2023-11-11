using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.Model;
using AplicativoPromotor.ViewModel.ProdutosPage;

namespace AplicativoPromotor.Produtos.Economy
{
    public class Schin : ProductViewModel
    {
        public Schin()
        {
            AddProduto(new ProductModel { Name = "Schin 350ml Puro Malte", Id = 78934115, Desc = "Cerveja do tipo Puro Malte", Foto = "schin350.png" });

        }
    }
}
