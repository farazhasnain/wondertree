using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WonderTree_API.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        public string UserID { get; set; } = Guid.NewGuid().ToString();
        public string Full_Name { get; set; }
        public string Email { get; set; }
    }
}