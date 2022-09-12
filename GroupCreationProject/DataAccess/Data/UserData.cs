using DataAccess.DBAccess;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.sqlUser_GetAll", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>(
                storedProcedure: "dbo.sqlUser_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.sqlUser_Insert", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.sqlUser_Update", user);

        public Task DeleteUser(int id) =>
            _db.SaveData(storedProcedure: "dbo.sqlUser_Delete", new { Id = id });
    }
}
