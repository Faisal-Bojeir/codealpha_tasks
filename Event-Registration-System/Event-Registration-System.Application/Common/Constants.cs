using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.Common
{
    public class Constants
    {
        public static class AdminRoutes
        {
            public const string AddEvent = "Add/Event";
            public const string GetEvents = "Events";
            public const string GetActiveEvents = "Active/Events";
            public const string RemoveEvent = "Remove";
        }

        public static class AuthRoutes
        {
            public const string Login = "Auth/Login";
            public const string SignUp = "Auth/SignUp";
        }
        public static class UserRoutes
        {
            public const string JoinToEvent = "Join";
            public const string CancelJoin = "Cancel";
            public const string GetAllEvents = "All";
            public const string GetMyEvents = "My";
        }

    }
}
