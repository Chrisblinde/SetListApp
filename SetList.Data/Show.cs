using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Data
{
    public class Show
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int ShowId { get; set; }
        [Required]
        public Band BandName { get; set; }
        [Required]
        public string Venue { get; set; }
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string SetList { get; set; }


    }
}
