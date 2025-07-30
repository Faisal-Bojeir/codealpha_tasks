using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Entities;

namespace URL_Shortener.EF.Dtos.NewShortLink
{
    public static class NewShortLinkMap
    {
        public static ShortenedLinks Map(this NewShortLinkDto dto)
        {
            return new()
            {
                OriginalUrl = dto.OriginalUrl,
                Note = dto.Note,
                ShortCode = dto.ShortCode,
            };
        }

        public static ShortenedLinks Map(string code, string originalUrl)
        {
            return new()
            {
                OriginalUrl = originalUrl,
                Note = "",
                ShortCode = code,
            };
        }
    }
}
