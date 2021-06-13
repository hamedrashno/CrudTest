using HamedRashnoCrudTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HamedRashnoCrudTest.Domain.Customer
{
    public class CustomerEntity : BaseEntity
    {
        [MaxLength(50)]
        public String FirstName { get; set; }

        [MaxLength(50)]
        public String LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }

        [MaxLength(254)]
        public String Email { get; set; }

        [MaxLength(30)]
        public String BankAccountNumber { get; set; }
    }
}
