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

        // TODO: Később át kell írni aszinkron módra!
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

        public static List<Versenyző> VSelect(string _név = "", string _csapat = "")
        {
            List<Versenyző> versenyzők = new();
            con.Open();
            string sql = "SELECT v.ID, v.név, v.nemzet, v.születés, v.magasság, v.csapatID, c.csapatnév " + 
                "FROM versenyzők v INNER JOIN csapatok c ON v.csapatID = c.ID " + 
                "WHERE c.csapatnév LIKE CONCAT('%',@csapat) AND v.név LIKE CONCAT('%',@név,'%');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@név", _név);
            cmd.Parameters.AddWithValue("@csapat", _csapat);
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                versenyzők.Add(new Versenyző(reader));
            }
            con.Close();
            return versenyzők;
        }

        public static void Delete(Versenyző v)
        {
            con.Open();
            string sql = "DELETE FROM versenyzők WHERE versenyzők.ID = " + v.ID;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void INSERT(Versenyző v)
        {
            con.Open();
            string sql =
                "INSERT INTO versenyzők(név, nemzet, születés, magasság, csapatID) " +
                "VALUES(@név, @nemzet, @születés, @magasság, @csapat);";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@név", v.Név);
            cmd.Parameters.AddWithValue("@nemzet", v.Nemzet);
            cmd.Parameters.AddWithValue("@születés", v.Születés);
            cmd.Parameters.AddWithValue("@magasság", v.Magasság);
            cmd.Parameters.AddWithValue("@csapat", v.CsapatID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void Update(Versenyző v)
        {
            con.Open();
            string sql =
                "UPDATE versenyzők SET név=@név, nemzet=@nemzet," +
                "születés=@születés, magasság=@magasság, csapatID=@csapat " +
                "WHERE ID = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@név", v.Név);
            cmd.Parameters.AddWithValue("@nemzet", v.Nemzet);
            cmd.Parameters.AddWithValue("@születés", v.Születés);
            cmd.Parameters.AddWithValue("@magasság", v.Magasság);
            cmd.Parameters.AddWithValue("@csapat", v.CsapatID);
            cmd.Parameters.AddWithValue("@id", v.ID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            con.Close() ;
        }
    }
}
