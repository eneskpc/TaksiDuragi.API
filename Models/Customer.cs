using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
