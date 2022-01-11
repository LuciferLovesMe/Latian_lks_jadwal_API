using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lks_jadwal_API.Models;

namespace lks_jadwal_API.Controllers
{
    public class AdminController : ApiController
    {
        List<AdminModel> models;
        lks_jadwalEntities row = new lks_jadwalEntities();

        [HttpPost]
        public IHttpActionResult post(user u)
        {
            string sql = "select * from [dbo].[user] where username = '" + u.username + "' and password = '" + u.password + "' and role = 'admin'";
            var us = row.users.SqlQuery(sql).FirstOrDefault();
            if (us != null)
            {
                AdminModel m = new AdminModel();
                m.id = us.userId;
                m.name = us.username;

                return Ok(m);
            }

            return Ok(us);
        }
    }
}
