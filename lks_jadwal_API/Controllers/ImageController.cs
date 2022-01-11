using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lks_jadwal_API.Models;

namespace lks_jadwal_API.Controllers
{
    public class ImageController : ApiController
    {
        SqlConnection connection = new SqlConnection(Conn.conn);
        JadwalEntities ent = new JadwalEntities();

        [HttpGet]
        public MemoryStream image()
        {
            SqlCommand command = new SqlCommand("select * from student where photo is not null", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //byte[] b = File.ReadAllBytes(reader["photo"].ToString());
                byte[] b = (byte[])reader["photo"];
                MemoryStream stream = new MemoryStream(b);
                Image photo = Image.FromStream(stream) ;

                return stream;
            }

            return null;
        }
    }
}
