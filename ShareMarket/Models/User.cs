using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShareMarket.Models
{
	[Serializable]
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }

		public User(params object[] reader)
		{
			Id =Convert.ToInt32(reader[0]);
			Name = reader[1].ToString();
			Username = reader[2].ToString();
			Password= reader[3].ToString();
			IsActive = Convert.ToBoolean(true);
		}
	}
}
/*
 * ---------------------------------------
 *                  Scripts
 * ---------------------------------------
 * 
 * # To Create table
 *      Create table Users(
			Id int primary key identity(1,1),
			[Name] varchar(20) not null,
			Email varchar(20) Unique not null check(Email Like '%@%.%'),
			[Password] varchar(30) not null,
			IsActive bit default(0)
			);
 * 
 * 
 * 
 */
