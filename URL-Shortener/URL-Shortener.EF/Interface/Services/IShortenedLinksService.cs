using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Entities;
using URL_Shortener.EF.Common;
using URL_Shortener.EF.Dtos.GetShortLink;
using URL_Shortener.EF.Dtos.NewShortLink;

namespace URL_Shortener.EF.Interface.Services
{
    public interface IShortenedLinksService
    {
        Task<Result> AddShortLink(NewShortLinkDto dto);
        Task<Result> AddShortLink(string code, string originalUrl);
        Task<Result> GetTheOriginalLinkInfo(GetShortLinkRequestDto dto);
        Task<string> GetTheOriginalLink(string shortCode);
    }
}
