using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmTest
{
    public class sqlConnection
    {
        public static SqlConnection baglanti = null;
        public static string baglanticumlesi = "Data Source=DESKTOP-849ONI1\\SQLEXPRESS;Initial Catalog=MekaLevyDB;Integrated Security=True";

        public SqlConnection baglan()
        {
            try
            {

                baglanti = new SqlConnection(baglanticumlesi);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    //string kayit = "insert into Alarm (AlarmId, AlarmAdi, AlarmLevel, AlarmTarihi) values(@AlarmId, @AlarmAdi, @AlarmLevel, @AlarmTarihi)";
                    //SqlCommand komut = new SqlCommand(kayit, baglanti);
                    //komut.Parameters.AddWithValue
                }
            }
            catch (global::System.Exception)
            {
                baglanti.Close();
            }
            return baglanti;

        }
        public void baglan_close()
        {
            baglanti = new SqlConnection(baglanticumlesi);
            baglanti.Dispose();
            baglanti.Close();
        }
    }
}
