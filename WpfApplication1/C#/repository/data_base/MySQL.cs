using System.Configuration;

using MySql.Data.MySqlClient;

namespace WpfApplication1.repository
{
    public class MySQL : AbstractBDD
    {
        public MySQL()
        {
            this.OpenConnection();
        }
        
        public override string PrepareConnection()
        {
            var server = ConfigurationManager.AppSettings["server"];
            var dbname = ConfigurationManager.AppSettings["dbname"];
            var user = ConfigurationManager.AppSettings["user"];
            var password = ConfigurationManager.AppSettings["password"];

            var connectionString = "SERVER=" + server + "; DATABASE=" + dbname + "; UID=" + user + "; PASSWORD=" +
                                      password;
            return connectionString;
        }

        public override void OpenConnection()
        {
            var connectionString = this.PrepareConnection();
            
            this.connection = new MySqlConnection(connectionString);
            
            this.connection.Open();
        }
        
    }
}