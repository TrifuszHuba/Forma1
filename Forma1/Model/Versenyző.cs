using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1.Model
{
    public class Versenyző
    {
        public int ID { get; set; }
        public string Név { get; set; }
        public int CsapatID { get; set; }
        public DateTime Születés { get; set; }
        public string? Nemzet { get; set; }
        public int? Magasság { get; set; }

        public Versenyző(){            
        } // INSERT-hez

        public Versenyző(MySqlDataReader reader)
        {
            ID = reader.GetInt32("ID");
            Név = reader["név"].ToString();
            CsapatID = (int)reader["csapatID"];
            Nemzet = reader["nemzet"] == DBNull.Value ? null : reader["nemzet"].ToString();
            Születés = Convert.ToDateTime(reader["születés"]);
            Magasság = reader["magasság"] == DBNull.Value ? null : (int)reader["magasság"];
        }

    }
}
