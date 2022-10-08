using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class CategoryListData : ICategoryListData
{
    private readonly ISqlDataAccess _db;

    public CategoryListData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CategoryListModel>> GetCategoryLists() =>
        _db.LoadData<CategoryListModel, dynamic>("dbo.spCategoryList_GetAll", new { });

    public async Task<CategoryListModel?> GetCategoryList(int id)
    {
        var results = await _db.LoadData<CategoryListModel, dynamic>(
            "dbo.spCategoryList_Get",
            new { CategoryListId = id });
        return results.FirstOrDefault();
    }

    public Task InsertCategoryList(CategoryListModel categoryList) =>
        _db.SaveData("dbo.spCategoryList_Insert", new {
            categoryList.CategoryListId,
            categoryList.Name,
            categoryList.Details
        });

    public Task UpdateCategoryList(CategoryListModel categoryList) =>
        _db.SaveData("dbo.spCategoryList_Update", categoryList);

    public Task DeleteCategoryList(int id) =>
        _db.SaveData("dbo.spCategoryList_Delete", new { CategoryListId = id });
}
