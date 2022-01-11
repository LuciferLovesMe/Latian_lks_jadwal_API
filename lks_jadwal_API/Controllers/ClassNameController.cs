using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lks_jadwal_API.Models;

namespace lks_jadwal_API.Controllers
{
    public class ClassNameController : ApiController
    {
        SqlConnection connection = new SqlConnection(Conn.conn);
        List<ClassModel> models = new List<ClassModel>();

        public List<ClassModel> get()
        {
            SqlCommand command = new SqlCommand("select * from class", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                models.Add(new ClassModel()
                {
                    id = Convert.ToInt32(reader["classid"]),
                    name = reader["name"].ToString()
                });
            }

            connection.Close();
            return models;
        }
    }
}
