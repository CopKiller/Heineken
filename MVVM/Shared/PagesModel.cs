using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVM.Shared
{
    public class PagesModel
    {
        public int TotalCentimetros { get; set; } = 0;
        public int PortfolioCentimetros { get; set; } = 0;
        public ProdutosModel[] Produtos { get; set; }

        public PagesModel() 
        {

        }

        public PagesModel(ProdutosModel[] produtos)
        {
            Produtos = produtos;
        }
    }
}
