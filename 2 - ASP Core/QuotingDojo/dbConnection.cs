using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
 
namespace QuotingDojo{
    public class DbConnector{
        static string server = "localhost";
        static string db = "codingdojo"; //Change to your schema name
        static string port = "8889"; //Potentially 8889
        static string user = "imdb";
        static string pass = "movie";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        
        //This method runs a query and stores the response in a list of dictionary records
        public static List<Dictionary<string, object>> Query(string queryString){
            using(IDbConnection dbConnection = Connection){
                using(IDbCommand command = dbConnection.CreateCommand()){
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader()){
                      while(rdr.Read()){
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ){
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
	    	          }
                          result.Add(dict);
                      }
                      return result;
                   }
                }
            }
        }
        //This method run a query and returns no values
        public static void Execute(string queryString){
            using (IDbConnection dbConnection = Connection){
                using(IDbCommand command = dbConnection.CreateCommand()){
                    command.CommandText = queryString;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
