using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.ViewModels
{
    public class CategoryIndexViewModel
    {
        public string p { get; set; }
        public List<CategoryViewModell> Cateories { get; set; } = new List<CategoryViewModell>();
        

    }
}
