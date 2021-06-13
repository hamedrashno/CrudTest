using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HamedRashnoCrudTest.Domain.Customer.ViewModels
{
   public class CustomerDetailsViewModel:CustomerCreateViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}
