using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaksiDuragi.API.Models
{
    public partial class Caller
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string LineNumber { get; set; }
        public string CallerNumber { get; set; }
        public DateTime CallDateTime { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
