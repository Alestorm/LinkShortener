using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.DTOS.LinkDtos
{
    public class LinkDto
    {
        public long IdLink { get; set; }
        public string Url { get; set; } = null!;
        public string ShortUrl { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int Frequency { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public long IdUser { get; set; }
    }
}