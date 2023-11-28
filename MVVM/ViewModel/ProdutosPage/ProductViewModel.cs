using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.MVVM.Model.ProdutosPage;

namespace AplicativoPromotor.MVVM.ViewModel.ProdutosPage
{
    public class ProductViewModel
    {
        private List<ProductModel> items = new List<ProductModel>();

        public ProductViewModel()
        {
            items = new List<ProductModel>();
        }

        public void AddProduto(ProductModel produto)
        {
            items.Add(produto);
        }

        public List<ProductModel> GetProdutos()
        {
            return items;
        }
    }
}
