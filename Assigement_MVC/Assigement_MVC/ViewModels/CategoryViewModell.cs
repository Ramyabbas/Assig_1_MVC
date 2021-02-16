using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.ViewModels
{
    public class CategoryViewModell
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductViewModell> products { get; set; }
    }
}
