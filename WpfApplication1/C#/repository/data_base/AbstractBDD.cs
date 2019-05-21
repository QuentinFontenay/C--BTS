using System.Collections.Generic;
using System.Data.OracleClient;
using System.Runtime.Remoting;
using System.Windows.Documents;

namespace WpfApplication1.repository
{
    public abstract class AbstractBDD
    {
        public System.Data.Common.DbConnection connection;
        
        public abstract string PrepareConnection();

        public abstract void OpenConnection();
    }
}