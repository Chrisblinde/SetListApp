using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Models
{
    public class BandDetail
    {
        [Required]
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Members { get; set; }
        [Display(Name = "Years Active")]
        public string YearsActive { get; set; }
        [Display(Name = "Number Of Albums")]
        public int NumberOfAlbums { get; set; }
    }
}
