using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos
{
    public class Produto
    {
        public ulong id { get; set; } //EAN do produto
        public string name { get; set; } //Nome do produto
        public string desc { get; set; } //Descrição do produto
        public string foto {  get; set; } //Nome do arquivo de imagem + extensão do produto
    }
}
