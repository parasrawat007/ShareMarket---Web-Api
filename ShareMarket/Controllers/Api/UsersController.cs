using ShareMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<User> GetUsers()
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
                    Users.Add(new User(reader[0],reader[1],reader[2],reader[3],reader[4]));
                }
                con.Close();
            }
           
            return Users.AsEnumerable();
        }
        [HttpPost]
        public User CreateUsers(User user)
        {

            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            using (con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\1\OfficePro\ShareMarket\ShareMarket\App_Data\Database1.mdf; Integrated Security = True"))
            {
                SqlCommand cmd = new SqlCommand("USP_CreateUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Name = new SqlParameter()
                {
                    ParameterName="@Name",
                    Value=user.Name,
                    Direction=ParameterDirection.Input
                };
                SqlParameter Email = new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = user.Email,
                    Direction = ParameterDirection.Input
                };
                SqlParameter Username = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = user.Username,
                    Direction = ParameterDirection.Input
                };
                SqlParameter Password = new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = user.Password,
                    Direction = ParameterDirection.Input
                };
                SqlParameter IsActive = new SqlParameter()
                {
                    ParameterName = "@IsActive",
                    Value = user.IsActive,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(Name);
                cmd.Parameters.Add(Email);
                cmd.Parameters.Add(Username);
                cmd.Parameters.Add(Password);
                cmd.Parameters.Add(IsActive);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                user =new User(reader[0], reader[1], reader[2], reader[3], reader[4]);
                
            
                con.Close();
            }

            return user;
        }
    }
}
