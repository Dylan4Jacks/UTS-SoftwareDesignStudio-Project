﻿using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class CategorySelectionData : ICategorySelectionData
{
    private readonly ISqlDataAccess _db;

    public CategorySelectionData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CategorySelectionModel>> GetCategorySelections() =>
        _db.LoadData<CategorySelectionModel, dynamic>("dbo.spCategorySelection_GetAll", new { });

    public async Task<CategorySelectionModel?> GetCategorySelection(int studentId, int categoryItemId)
    {
        var results = await _db.LoadData<CategorySelectionModel, dynamic>(
            "dbo.spCategorySelection_Get",
            new { CategoryItemId = categoryItemId, StudentId = studentId });
        return results.FirstOrDefault();
    }

    public async Task<CategorySelectionModel?> GetCategorySelectionStudent(int studentId)
    {
        var results = await _db.LoadData<CategorySelectionModel, dynamic>(
            "dbo.spCategorySelection_Student_Get",
            new { StudentId = studentId });
        return results.FirstOrDefault();
    }

    public async Task<CategorySelectionModel?> GetCategorySelectionItem(int categoryItemId)
    {
        var results = await _db.LoadData<CategorySelectionModel, dynamic>(
            "dbo.spCategorySelection_Item_Get",
            new { CategoryItemId = categoryItemId });
        return results.FirstOrDefault();
    }

    public Task InsertCategorySelection(CategorySelectionModel categorySelection) =>
        _db.SaveData("dbo.spCategorySelection_Insert", new {
            categorySelection.CategoryItemId,
            categorySelection.StudentId,
            categorySelection.Content
        });

    public Task UpdateCategorySelection(CategorySelectionModel categorySelection) =>
        _db.SaveData("dbo.spCategorySelection_Update", categorySelection);

    public Task DeleteCategorySelection(int studentId, int categoryItemId) =>
        _db.SaveData("dbo.spCategorySelection_Delete", new { CategoryItemId = categoryItemId, StudentId = studentId });
}
