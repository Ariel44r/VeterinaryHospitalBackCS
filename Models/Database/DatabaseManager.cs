using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class DatabaseManager
{    
    S _s = new S();
    public T[] SqlConnection<T>() {
        T[] wildCard = {};
        string connStr = _s.connectionString;
        using (SqlConnection con = new SqlConnection(connStr)) {
            con.Open();
            try {
                using (SqlCommand command = new SqlCommand(_s.currentQuery, con)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {  
                        return JsonConvert.DeserializeObject<T[]>(sqlDataToJson(reader)); 
                    }
                }
            }
            catch (Exception err) {
                Console.WriteLine(err.ToString());
            }
        }
        return wildCard;
    }

    public String sqlDataToJson(SqlDataReader dataReader)
    {
        var dataTable = new DataTable();
        dataTable.Load(dataReader);
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(dataTable);
        return JSONString;
    }

}
