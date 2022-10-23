using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class GroupData : IGroupData
{
    private readonly ISqlDataAccess _db;

    public GroupData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<GroupModel>> GetGroups() =>
        _db.LoadData<GroupModel, dynamic>("dbo.spGroup_GetAll", new { });

    public async Task<GroupModel?> GetGroup(int id)
    {
        var results = await _db.LoadData<GroupModel, dynamic>(
            "dbo.spGroup_Get",
            new { GroupId = id });
        return results.FirstOrDefault();
    }

    public Task InsertGroup(GroupModel group) =>
        _db.SaveData("dbo.spGroup_Insert", new {
            group.GroupId,
            group.GroupName,
            group.Details
        });

    public Task UpdateGroup(GroupModel group) =>
        _db.SaveData("dbo.spGroup_Update", group);

    public Task DeleteGroup(int id) =>
        _db.SaveData("dbo.spGroup_Delete", new { GroupId = id });
}
