using System;
using System.Collections.Generic;

namespace TaksiDuragi.API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string TaxiStationName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string AuthCode { get; set; }
        public DateTime? ExpireTime { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
