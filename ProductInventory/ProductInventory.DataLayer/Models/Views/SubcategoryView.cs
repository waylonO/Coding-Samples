using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.DataLayer.Models.Views
{
    public class SubcategoryView
    {
        public int SubcategoryId { get; set; }
        public int CategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
    }
}
