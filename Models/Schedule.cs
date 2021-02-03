using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ByteClubSite.Models
{
    public class Schedule
    {
        public string Name { get; set; } //Class name
        public int Period { get; set; } //Period Number (auto-increment?)
        public bool isEmpty { get; set; } //Is there a class here
        public string Start { get; set; } //Start time (ex: 23:59)
        public string StartLate { get; set; } //Start time on Late Start
        public string StartEarlyDismiss { get; set; } //Start time on Early Dismissal
    }
}
