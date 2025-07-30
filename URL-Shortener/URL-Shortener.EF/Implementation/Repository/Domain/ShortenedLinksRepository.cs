using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Entities;
using URL_Shortener.EF.Data;
using URL_Shortener.EF.Implementation.Repository;
using URL_Shortener.EF.Interface;
using URL_Shortener.EF.Interface.Domain;

namespace URL_Shortener.EF.Implementation.Repository.Domain
{
    public class ShortenedLinksRepository : BaseRepository<ShortenedLinks>, IShortenedLinksRepository
    {
        public ShortenedLinksRepository(AppDbContext context) : base(context)
        {
        }
    }
}
