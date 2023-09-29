using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Refrigerante
{
    public class Fys
    {
        public List<Produto> items = new List<Produto>();
        public Fys()
        {
            items.Add(new Produto { name = "Fys 350ml Laranja", id = 7896052607129, desc = "Refrigerante sem conservantes sabor Laranja", foto = "devassa269.png" });
            items.Add(new Produto { name = "Fys 350ml Guarana", id = 7896052607044, desc = "Refrigerante sem conservantes sabor Guarana", foto = "devassa269.png" });
            items.Add(new Produto { name = "Fys 350ml Tônica", id = 7896052607228, desc = "Agua tônica sabor limão siciliano", foto = "devassa269.png" });
            items.Add(new Produto { name = "Fys 350ml Tônica Zero", id = 7896052607587, desc = "Agua tônica sabor limão siciliano sem açucar", foto = "devassa269.png" });
        }
    }
}
