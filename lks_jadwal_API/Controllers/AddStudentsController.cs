using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lks_jadwal_API.Models;

namespace lks_jadwal_API.Controllers
{
    public class AddStudentsController : ApiController
    {
        List<StudentsModel> models = new List<StudentsModel>();
        SqlConnection connection = new SqlConnection(Conn.conn);

        [HttpPost]
        public string[] post ([FromBody] AddStudentsModel students)
        {
            SqlCommand sql = new SqlCommand("insert into [dbo].[user] values('" + getuser() + "', '123123123', 'student')", connection);

            //DateTime date = DateTime.ParseExact(students.dob, "M-d-yyyy", CultureInfo.InvariantCulture);
            connection.Open();
            sql.ExecuteNonQuery();
            connection.Close();

            SqlCommand read = new SqlCommand("select top (1) * from [dbo].[user] where role = 'student' order by userid desc", connection);
            connection.Open();
            SqlDataReader reader = read.ExecuteReader();
            reader.Read();
            int userid = Convert.ToInt32(reader["userid"]);
            connection.Close();



            SqlCommand command = new SqlCommand("insert into student(name, address, gender, dateofbirth, nohp, classid, userid) values('" + students.name + "', '" + students.address + "', '" + students.gender + "', @dob, '" + students.hp + "', " + students.classid + ", " + userid + ")", connection);
            //SqlCommand command = new SqlCommand("insert into student(name, address, gender, dateofbirth, nohp, classid, userid) values('" + students.name + "', '" + students.address + "', '" + students.gender + "', '" + date + "', '" + students.hp + "', " + students.classid + ", " + userid + ")", connection);
            connection.Open();
            command.Parameters.AddWithValue("@dob", Convert.ToDateTime(students.dob));
            command.ExecuteNonQuery();
            connection.Close();

            return new string[] { "Success" };

        }

        public string getuser()
        {
            SqlCommand command = new SqlCommand("select COUNT(*) as num from [dbo].[user] where role = 'student'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int last = Convert.ToInt32(reader["num"]) + 1;
                connection.Close();
                return "STU" + last.ToString();
            }

            connection.Close();
            return "STU1";
        }
    }
}
