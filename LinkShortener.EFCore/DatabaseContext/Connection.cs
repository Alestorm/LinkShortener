using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore.DatabaseContext
{
    public class Connection
    {
        public static string SetConnectionString(string server, string database, string user, string password)
        {
            string connectionString = string.Empty;

            try
            {
                connectionString = "Persist Security Info=True;User ID=" + user + ";Pwd=" + password + ";Server=" + server + ";Database=" + database + ";MultipleActiveResultSets=True;TrustServerCertificate=true";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return connectionString;
        }
    }
}
