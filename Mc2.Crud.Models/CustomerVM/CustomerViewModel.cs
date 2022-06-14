using System;

namespace Mc2.Crud.Models
{
    public class CustomerViewModel
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
