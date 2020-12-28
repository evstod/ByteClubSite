using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ByteClubSite.Models
{
    public class BlogPost
    {
        [JsonIgnore]
        public int Id { get; set; } //I dont remember why this is here.

        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string Images { get; set; }
    }
}
