using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Logic
{
    public static class UserProcessor
    {
        public static int CreateUser(string firstName, string lastName,string emailAddress)
        {
            UserModel data = new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress

            };

            string sql = "dbo.User_Insert @firstName, @lastName, @emailAddress";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<UserModel> LoadUserList()
        {
            string sql = "dbo.Load_UserList";

            return SqlDataAccess.LoadData<UserModel>(sql);


        }
    }
}
