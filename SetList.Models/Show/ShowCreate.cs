using SetList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Models.Show
{
    public class ShowCreate
    {

        [Required]
        public string Venue { get; set; }
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Display(Name = "Set List")]
        public string SetList { get; set; }
        [Display(Name = "Band Name")]
        public string BandName => Band.Name;
        public Band Band { get; private set;}
           
        
    }
}
