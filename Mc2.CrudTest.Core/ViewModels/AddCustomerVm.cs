﻿using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Core.ViewModels
{
    public class AddCustomerVm
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public ulong PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string BankAccountNumber { get; set; }
    }
}
