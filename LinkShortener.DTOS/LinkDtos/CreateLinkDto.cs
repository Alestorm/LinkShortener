using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.DTOS.LinkDtos
{
    public class CreateLinkDto
    {
        [Required]
        public string Url { get; set; } = string.Empty;
        [DefaultValue(1)]
        public long IdUser { get; set; } = 1;
    }
}