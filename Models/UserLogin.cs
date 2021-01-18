using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ByteClubSite.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime createDate { get; set; }
        [Required]
        public int hasEditorRights { get; set; }
    }
}
