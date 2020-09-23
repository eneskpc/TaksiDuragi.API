using System;
using System.Collections.Generic;

namespace TaksiDuragi.API.Models
{
    public partial class Driver
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public string TaxiPlaque { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
