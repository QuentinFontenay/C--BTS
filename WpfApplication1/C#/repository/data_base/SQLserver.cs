using System.Configuration;
using System.Data.SqlClient;


namespace WpfApplication1.repository
{
    public class SQLserver : AbstractBDD
    {

        public SQLserver()
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

        public sealed override void OpenConnection()
        {
            var connectionString = this.PrepareConnection();
            
            this.connection = new SqlConnection(connectionString);
            
            this.connection.Open();
        }
        
    }
}