using Assigement_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.ViewModels
{
    public class PorductEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Var vänlig och skriv in namnet")]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required(ErrorMessage = "Var vänlig och skriv in beskrivningen")]
        [MaxLength(1000)]
        public string Description { get; set; }
        public List<SelectListItem> cateories { get; set; }

    }
}
