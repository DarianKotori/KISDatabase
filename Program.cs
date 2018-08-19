using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using System.Configuration;
using System.Text;

namespace KISDatabase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Utilities.kis_clients.ConnectionString = Utilities.connections["KISDatabase.Properties.Settings.kis_clientsConnectionString"].ToString();
            Utilities.kis_clients.Open();
            new Login();
            Application.Run();
        }
    }

    //Contains several utility functions and stores database connection object
    public class Utilities
    {
        public static ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
        public static OdbcConnection kis_clients = new OdbcConnection();

        //sanitize strings for use in queries
        public static string MySQL_String(string query)
        {
            return Regex.Replace(query, @"['""\\]", "",
                                    RegexOptions.None, TimeSpan.FromSeconds(1.5));
        }
        
        //used to set default dates for the reporting form
        public static DateTime getReportingYearStart(DateTime day)
        {
            int year = (day.Month < 4 ? day.Year - 1 : day.Year);
            return new DateTime(year, 4, 1);
        }

        //used to set default dates for the reporting form
        public static DateTime getReportingYearEnd(DateTime day)
        {
            int year = (day.Month < 4 ? day.Year : day.Year + 1);
            return new DateTime(year, 3, 31);
        }

        //artifact function
        public static int getReportingYear(DateTime day)
        {
            return (day.Month < 4 ? day.Year - 1 : day.Year);
        }

        //Turn raw password hash into a string usable in queries
        public static string buildPwd(byte[] hash)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    //Holds data of the logged-in user for easy reference
    static class UserData
    {
        public static string username = "";
        public static int userID = 0;
    }
}
