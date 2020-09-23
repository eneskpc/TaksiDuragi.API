using System;
using System.Collections.Generic;

namespace TaksiDuragi.API.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
