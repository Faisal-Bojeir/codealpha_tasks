using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Const;
using URL_Shortener.Core.Entities;
using URL_Shortener.EF.Common;
using URL_Shortener.EF.Dtos.GetShortLink;
using URL_Shortener.EF.Dtos.NewShortLink;
using URL_Shortener.EF.Interface.Domain;
using URL_Shortener.EF.Interface.Services;

namespace URL_Shortener.EF.Implementation.Services
{
    public class ShortenedLinksService : IShortenedLinksService
    {
        private readonly IShortenedLinksRepository _repository;

        public ShortenedLinksService(IShortenedLinksRepository repository)
        {
            _repository = repository;
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public async Task<Result> AddShortLink(NewShortLinkDto dto)
        {
            if (IsValidUrl(dto.OriginalUrl))
            {
                var entity = dto.Map();
                await _repository.CreateAsync(entity);
                return new Result(true, ResultMessage.AddMessage, StatusCode.Created);
            }
            else
                return new Result(false, ResultMessage.UnprocessableEntityMessage, StatusCode.UnprocessableEntity);
        }

        public async Task<Result> AddShortLink(string code, string originalUrl)
        {
            if (IsValidUrl(originalUrl))
            {
                var entity = NewShortLinkMap.Map(code, originalUrl);
                await _repository.CreateAsync(entity);
                return new Result(true, ResultMessage.AddMessage, StatusCode.Created);
            }
            else
                return new Result(false, ResultMessage.UnprocessableEntityMessage, StatusCode.UnprocessableEntity);
        }

        //For a developer who will use my api
        public async Task<Result> GetTheOriginalLinkInfo(GetShortLinkRequestDto dto)
        {
            Expression<Func<ShortenedLinks, bool>> condition = c => c.ShortCode.ToLower() == dto.ShortenerCode.ToLower();
            var link = await _repository.GetByConditionAsync(condition);
            if (link is null)
                return new(false, ResultMessage.NotFound, StatusCode.NotFound);
            var data = link.Map();
            return new(true, ResultMessage.FoundMessage, StatusCode.OK, data);
        }

        //for a regular user
        public async Task<string> GetTheOriginalLink(string shortCode)
        {
            Expression<Func<ShortenedLinks, bool>> condition = c => c.ShortCode.ToLower() == shortCode;
            var link = await _repository.GetByConditionAsync(condition);
            if (link is null)
                return null;
            var data = link.Map();
            return link.OriginalUrl;
        }
    }
}
