using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVM.Model.SoviPage
{
    public class CategoryModel
    {
        public string CategoryName { get; set; }
        public int TotalSpace { get; set; }
        public int CategorySpace { get; set; }
        public ProductsModel[] Products { get; set; }
    }

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
        public double Percentage { get; set; }
    }
}
