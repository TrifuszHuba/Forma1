using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1.Model
{
    public class Csapat
    {
        public int ID { get; set; }
        public string Csapatnév { get; set; }
        public string Főnök { get; set; }
        public string Nemzet { get; set; }

        public Csapat() { 
            Csapatnév = string.Empty;
        }
        public Csapat(MySqlDataReader reader)
        {
            ID = (int)reader["ID"];
            Csapatnév = reader["csapatnév"].ToString();
            Főnök = reader["főnök"].ToString();
            Nemzet = reader["nemzet"].ToString();

        }
    }
}
