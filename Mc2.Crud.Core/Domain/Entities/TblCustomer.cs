using SharedKernel.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Mc2.Crud.Core.Entities
{
    public class TblCustomer : IAggregateRoot
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public int Id { get; set; }
    }
}
