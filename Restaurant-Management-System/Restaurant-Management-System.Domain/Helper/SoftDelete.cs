using Event_Registration_System.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Helper
{
    public static class SoftDelete
    {
        public static void Delete(ISoftDelete softDelete)
        {
            softDelete.IsDeleted = true;
        }

        public static void CancelDelete(ISoftDelete softDelete)
        {
            softDelete.IsDeleted = false;
        }
    }
}
