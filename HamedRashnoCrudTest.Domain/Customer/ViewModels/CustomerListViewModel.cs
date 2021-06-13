using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HamedRashnoCrudTest.Domain.Customer.ViewModels
{
   public class CustomerListViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "نام")]
        public String FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public String LastName { get; set; }

        [Display(Name = "ایمیل")]
        public String Email { get; set; }
    }
}
