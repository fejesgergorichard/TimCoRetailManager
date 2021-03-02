using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserDataAccess
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<UserModel, dynamic>("[dbo].[spUserLookup]", new { Id = id }, "TRMData").ToList();
            
            return output;
        }

        public void RegisterUser(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData<dynamic>("[dbo].[spRegisterUser]",
                new { user.Id, user.FirstName, user.LastName, user.EmailAddress }, "TRMData");
        }
    }
}
