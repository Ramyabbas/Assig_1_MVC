﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Assigement_MVC.ViewModels
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }

       [Required(ErrorMessage ="Var vänlig och skriv in namnet")]
       [MaxLength(30, ErrorMessage = "Maxlängd har uppnåt")]
        public string Name { get; set; }

        public List<SelectListItem> products { get; set; }

    }
}
