using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airlineOtomations.Models
{
    public class SelectPopulate
    {
        private string _connectionString;

        public SelectPopulate(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataTable GetDataTable(string tableName)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = $"SELECT * FROM {tableName}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, _connectionString);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                con.Close();
                return ds.Tables[0];
            }
        }
    }
}
