using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ByteClubSite.Models
{
    public class Agenda
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Body { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StartLate { get; set; }
        public TimeSpan StartEarlyDismiss { get; set; }
        public TimeSpan StartActivity { get; set; }
        //Maybe have templated rows where user just types in assignment name and details
        //Have "No class" checkbox; generate empty instance
    }
}
