using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaksiDuragi.API.Models
{
    public partial class UserDevice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
