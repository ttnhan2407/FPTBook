using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPTBookstore.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace FPTBookstore.Areas.Admin.Models
{
    public class LoginModel
    {
        //Call a LoginModel to equal with Admin in Models

        [Required(ErrorMessage = "You have not signed up yet")]
        [Display(Name = "Account")]
        public string Account { get; set; }

        [Required(ErrorMessage = "You have not entered your password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember")]
        public bool? Remember { get; set; }

        [Display(Name = "Fullname")]
        public string Fullname { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; }
    }
}