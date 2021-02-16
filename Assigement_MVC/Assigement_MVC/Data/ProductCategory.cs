using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
