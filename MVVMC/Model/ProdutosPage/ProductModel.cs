using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVMC.Model.ProdutosPage
{
    public struct ProductModel
    {
        public ulong Id { get; set; } //EAN do produto
        public string Name { get; set; } //Nome do produto
        public string Desc { get; set; } //Descrição do produto
        public string Foto { get; set; } //Nome do arquivo de imagem + extensão do produto
    }
}
