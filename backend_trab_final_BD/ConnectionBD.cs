using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class ConnectionBD
    {
        public static OracleConnection Connection()
        {

            
            string connStrLocalhost = "Data Source= (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
                "(CONNECT_DATA =(SERVICE_NAME = xe)));" +
                "User Id=iuryzanonni;password=123";
          
            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = connStrLocalhost;
            return connection;
        }
    }
}
