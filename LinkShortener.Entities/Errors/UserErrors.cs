using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Errors
{
    public static class UserErrors
    {
        public static readonly Error AlreadyExists = new Error("User.AlreadyExists", "The user is already registered");
        public static readonly Error NoUsers = new Error("User.NoUsers", "There are no registered users");
        public static readonly Error Unauthorized = new Error("User.Unauthorized", "Unauthorized access");
        public static readonly Error NotFound = new Error("User.NotFound", "User not found in database");
        public static readonly Error DatabaseError = new Error("User.DatabaseError", "There was an error trying to write in database");
    }
}
