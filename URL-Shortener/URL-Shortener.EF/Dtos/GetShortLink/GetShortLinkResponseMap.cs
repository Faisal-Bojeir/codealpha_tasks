using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Entities;

namespace URL_Shortener.EF.Dtos.GetShortLink
{
    public static class GetShortLinkResponseMap
    {
        public static GetShortLinkResponseDto Map(this ShortenedLinks shortenedLinks)
        {
            return new()
            {
                OriginalUrl = shortenedLinks.OriginalUrl,
                ShortCode = shortenedLinks.ShortCode,
                Note = shortenedLinks.Note,
            };
        }
    }
}
