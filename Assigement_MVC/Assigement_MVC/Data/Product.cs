using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.Data
{
    public class Product
    {

        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ProductCategory CategoryId { get; set; }

    }
}
