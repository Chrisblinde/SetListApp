﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Data
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Members { get; set; }
        [Display(Name = "Years Active")]
        public string YearsActive { get; set; }
        public int NumberOfAlbums { get; set; }
    }
}
        
