﻿using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class CategoryItemData : ICategoryItemData
{
    private readonly ISqlDataAccess _db;

    public CategoryItemData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CategoryItemModel>> GetCategoryItems() =>
        _db.LoadData<CategoryItemModel, dynamic>("dbo.spCategoryItem_GetAll", new { });

    public async Task<CategoryItemModel?> GetCategoryItem(int id)
    {
        var results = await _db.LoadData<CategoryItemModel, dynamic>(
            "dbo.spCategoryItem_Get",
            new { CategoryItemId = id });
        return results.FirstOrDefault();
    }

    public Task InsertCategoryItem(CategoryItemModel categoryItem) =>
        _db.SaveData("dbo.spCategoryItem_Insert", new {
            categoryItem.CategoryItemId,
            categoryItem.Name,
            categoryItem.Details,
            categoryItem.CategoryListId
        });

    public Task UpdateCategoryItem(CategoryItemModel categoryItem) =>
        _db.SaveData("dbo.spCategoryItem_Update", categoryItem);

    public Task DeleteCategoryItem(int id) =>
        _db.SaveData("dbo.spCategoryItem_Delete", new { CategoryItemId = id });
}
