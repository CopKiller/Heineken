﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Produtos.Economy
{
    public class Schin : Produtos
    {
        public Schin()
        {
            AddProduto(new Item { Name = "Schin 350ml Puro Malte", Id = 78934115, Desc = "Cerveja do tipo Puro Malte", Foto = "schin350.png" });

        }
    }
}
