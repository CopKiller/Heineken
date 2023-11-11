using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.Model;
using AplicativoPromotor.ViewModel.ProdutosPage;

namespace AplicativoPromotor.Produtos.Refrigerante
{
    public class Fys : ProductViewModel
    {
        public Fys()
        {
            AddProduto(new ProductModel { Name = "Fys 350ml Laranja", Id = 7896052607129, Desc = "Refrigerante sem conservantes sabor Laranja", Foto = "devassa269.png" });
            AddProduto(new ProductModel { Name = "Fys 350ml Guarana", Id = 7896052607044, Desc = "Refrigerante sem conservantes sabor Guarana", Foto = "devassa269.png" });
            AddProduto(new ProductModel { Name = "Fys 350ml Tônica", Id = 7896052607228, Desc = "Agua tônica sabor limão siciliano", Foto = "devassa269.png" });
            AddProduto(new ProductModel { Name = "Fys 350ml Tônica Zero", Id = 7896052607587, Desc = "Agua tônica sabor limão siciliano sem açucar", Foto = "devassa269.png" });
        }
    }
}
