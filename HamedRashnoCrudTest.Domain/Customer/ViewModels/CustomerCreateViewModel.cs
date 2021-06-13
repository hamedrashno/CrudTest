using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HamedRashnoCrudTest.Domain.Customer.ViewModels
{
  public  class CustomerCreateViewModel
    {
        [MaxLength(50)]
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} ضروری میباشد")]
        public String FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} ضروری میباشد")]
        public String LastName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "{0} ضروری میباشد")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "شماره تلفن")]
        [RegularExpression(@"^9\d{9}$", ErrorMessage = "{0}  معتبر نمیباشد، فرمت درست: 9123456789")]
        public ulong PhoneNumber { get; set; }

        [MaxLength(254)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} ضروری میباشد")]
        [EmailAddress]
        public String Email { get; set; }

        [MaxLength(30)]
        [Display(Name = "شماره حساب بانکی")]
        public String BankAccountNumber { get; set; }
    }
}
