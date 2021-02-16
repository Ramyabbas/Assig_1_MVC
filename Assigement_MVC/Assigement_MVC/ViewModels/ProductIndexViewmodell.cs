using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.ViewModels
{
    public class ProductIndexViewmodell
    {

        public string p { get; set; }
        public List<ProductViewModell> products { get; set; } = new List<ProductViewModell>();

    }
}
