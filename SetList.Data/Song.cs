using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Data
{
    public class Song
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public string Name { get; set; }
        public int TimesSeen { get; set; }


    }
}
