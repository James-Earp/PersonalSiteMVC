using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalSiteMVC.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Name is required")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "* Email is required")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        [UIHint("MultilineText")]
        public string Message { get; set; } 
    }
}