using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lks_jadwal_API.Models;

namespace lks_jadwal_API.Controllers
{
    public class StudentsController : ApiController
    {
        SqlConnection connection = new SqlConnection(Conn.conn);
        List<StudentsModel> models = new List<StudentsModel>();

        public List<StudentsModel> get()
        {
            SqlCommand command = new SqlCommand("select student.*, class.name as classname, [dbo].[user].username from student join [dbo].[user] on student.userid = [dbo].[user].userid join class on student.classid = class.classid", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                models.Add(new StudentsModel()
                {
                    id = Convert.ToInt32(reader["studentid"]),
                    name = reader["name"].ToString(),
                    address = reader["address"].ToString(),
                    classname = reader["classname"].ToString(),
                    date = reader["dateofbirth"].ToString(),
                    hp = reader["noHp"].ToString(),
                    username = reader["username"].ToString()
                });
            }

            return models;
        }
    }
}
