using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Contract
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
