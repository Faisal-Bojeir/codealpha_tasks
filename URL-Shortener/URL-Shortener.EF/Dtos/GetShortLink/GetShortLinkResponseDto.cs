using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.EF.Dtos.GetShortLink
{
    public class GetShortLinkResponseDto
    {
        public required string OriginalUrl { get; set; }
        public required string ShortCode { get; set; }
        public string? Note { get; set; }
    }
}
