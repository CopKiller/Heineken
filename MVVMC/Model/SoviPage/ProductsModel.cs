using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVMC.Model.SoviPage
{
    public class ProductsModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public SpaceModel Space { get; set; }

        public ProductsModel()
        {
            Space = new SpaceModel();
        }

    }

    public class SpaceModel
    {
        public int Centimeters { get; set; }
        public int Percentage { get; set; }
    }
}
