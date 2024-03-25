using Forma1.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1.ViewModel.Helper
{
    public class SqlData
    {
        static string conStr = "Server=localhost;Database=forma1;Uid=root;Pwd=";
        static MySqlConnection con = new(conStr);

        public static List<Csapat> Select()
        {
            List<Csapat> csapatok = new();
            csapatok.Add(new Csapat());
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM csapatok", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                csapatok.Add(new Csapat(reader));
            }
            con.Close();
            return csapatok;
        }

        public static List<Versenyző> VersenyzőSelect(string _név = "", string _csapat = "")
        {
            List<Versenyző> versenyzők = new();
            con.Open();
            string sql = "SELECT v.ID, v.név, v.nemzet, v.születés, v.magasság, c.csapatnév\r\nFROM versenyzők v INNER JOIN csapatok c ON v.csapatID = c.ID\r\nWHERE c.csapatnév LIKE CONCAT ('%', 'Ferrari') AND v.név LIKE CONCAT ('%', 'e' ,'%');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                versenyzők.Add(new Versenyző(reader));
            }
            con.Close();
            return versenyzők;
        }
    }
}
