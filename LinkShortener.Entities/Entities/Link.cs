using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Entities
{
    public class Link
    {
        [Key]
        public long IdLink { get; set; }
        public string Url { get; set; } = null!;
        public string ShortUrl { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int Frequency { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        [ForeignKey("IdUser")]
        public long IdUser { get; set; } = 1;
        public User User { get; set; } = null!;
    }
}