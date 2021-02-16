using System;
using System.Collections.Generic;
using Assigement_MVC.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.ViewModels
{
    public class SelectedCategoryViewModell
    {
        public string p { get; set; }
        public string SelectedCategoryName { get; set; }
        public List<ProductViewModell> products { get; set; }

    }
}
