using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.Model.SoviPage
{
    public class CategoryModel
    {
        public string CategoryName {  get; set; }
        public int TotalSpace {  get; set; }
        public int CategorySpace {  get; set; }
        public ProductsModel[] Products { get; set; }
    }
}
