using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Errors
{
    public class LinkErrors
    {
        public static readonly Error NotUrlFormat = new Error("Link.NotUrlFormat", "The text is not a valid url");
        public static readonly Error LinkListEmpty = new Error("Link.LinkListEmpty", "There are no links yet");
        public static readonly Error NotFoundLink = new Error("Link.NotFoundLink", "Couldn't find the link");
        public static readonly Error InvalidUser = new Error("Link.InvalidUser", "Invalid user Id");
        public static readonly Error DatabaseError = new Error("Link.DatabaseError", "There was an error trying to write in database");
    }
}
