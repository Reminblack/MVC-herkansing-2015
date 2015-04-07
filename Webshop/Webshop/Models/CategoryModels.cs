using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "Category name")]
        public string Name { get; set; }
    }
}