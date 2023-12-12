using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVM.Shared
{
    public class ProdutosModel
    {
        // Tipo, usado com enum
        public int produtoType { get; set; }
        // Numerico, recebido pela Entry
        public byte produtoSovi { get; set; }
        // Centimetros de cada box em array
        public int[] produtoCentimetro { get; set; }
    }
}
