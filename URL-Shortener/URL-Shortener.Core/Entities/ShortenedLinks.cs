using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Contract;

namespace URL_Shortener.Core.Entities
{
    public class ShortenedLinks : ISoftDelete
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortCode { get; set; }
        public string Note { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
