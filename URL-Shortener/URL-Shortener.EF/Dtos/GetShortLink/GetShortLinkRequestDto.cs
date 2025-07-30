using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.EF.Dtos.GetShortLink
{
    public class GetShortLinkRequestDto
    {
        [Required(ErrorMessage = "Shortener code is required!")]
        public required string ShortenerCode { get; set; }
    }
}
