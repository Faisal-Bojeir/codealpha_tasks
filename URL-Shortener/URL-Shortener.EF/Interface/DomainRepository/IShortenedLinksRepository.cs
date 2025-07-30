using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Entities;

namespace URL_Shortener.EF.Interface.Domain
{
    public interface IShortenedLinksRepository : IBaseRepository<ShortenedLinks>
    {
    }
}
