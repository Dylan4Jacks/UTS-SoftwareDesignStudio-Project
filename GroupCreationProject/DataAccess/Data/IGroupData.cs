using DataAccess.Models;

namespace DataAccess.Data;
public interface IGroupData
{
    Task DeleteGroup(int id);
    Task DeleteAllGroups();
    Task<GroupModel?> GetGroup(int id);
    Task<IEnumerable<GroupModel>> GetGroups();
    Task InsertGroup(GroupModel group);
    Task UpdateGroup(GroupModel group);
}