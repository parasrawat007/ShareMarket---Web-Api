using ShareMarket.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace ShareMarket.Controllers.Api
{
    public class UsersController : ApiController
    {
        private SqlConnection con;
        //public UsersController()
        //{
        //     con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\1\OfficePro\ShareMarket\ShareMarket\App_Data\Database1.mdf; Integrated Security = True");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    con.Close();
        //}
        //GET api/Users
        public IHttpActionResult GetUsers()
        {
            List<User> Users = new List<User>();
            using (con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\1\OfficePro\ShareMarket\ShareMarket\App_Data\Database1.mdf; Integrated Security = True"))
            {
                SqlCommand cmd = new SqlCommand("USP_GetUsers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Users.Add(new User(reader[0],reader[1],reader[2],reader[3],reader[4],reader[5]));
                }
                con.Close();
            }
           
            return Ok(Users);
        }

        [HttpPost]
        public IHttpActionResult CreateUsers(User user)
        {
            using (con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\1\OfficePro\ShareMarket\ShareMarket\App_Data\Database1.mdf; Integrated Security = True"))
            {
                SqlCommand cmd = new SqlCommand("USP_CreateUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();

                cmd.Parameters.AddWithValue("@Name",user.Name.ToString());
                cmd.Parameters.AddWithValue("@Email",user.Email.ToString());
                cmd.Parameters.AddWithValue("@username",user.Username.ToString());
                cmd.Parameters.AddWithValue("@Password",user.Password.ToString());
                cmd.Parameters.AddWithValue("@IsActive",user.IsActive.ToString());


                cmd.ExecuteNonQuery();

                con.Close();
            }

            return Ok(user);
        }
    }
}
