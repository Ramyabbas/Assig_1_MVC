using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.ViewModels
{
    public class CategoryNewViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Var vänlig och skriv in namnet")]
        [MaxLength(40)]
        public string Name { get; set; }
        public List<SelectListItem> products { get; set; } = new List<SelectListItem>();
    }
}
