using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.EF.Dtos.NewShortLink
{
    public class NewShortLinkDto
    {
        [Required(ErrorMessage = "Original link is required")]
        public required string OriginalUrl { get; set; }
        [Required(ErrorMessage = "ShortCode link is required")]
        public required string ShortCode { get; set; }
        public string? Note { get; set; }
    }
}
