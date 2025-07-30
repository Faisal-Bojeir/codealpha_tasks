using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.Core.Const
{
    public static class ApiRoutes
    {
        public static class ShortenerLink
        {
            public const string Base = "api/ShortenerLink";
            public const string GetByOriginalUrl = Base;
            public const string Create = Base;
            public const string RedirectTo = Base + "RedirectTo";
        }
    }
}
