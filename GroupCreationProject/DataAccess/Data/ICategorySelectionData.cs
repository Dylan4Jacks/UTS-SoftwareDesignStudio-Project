using DataAccess.Models;

namespace DataAccess.Data;
public interface ICategorySelectionData
{
    Task DeleteCategorySelection(int studentId, int categoryItemId);
    Task<CategorySelectionModel?> GetCategorySelection(int studentId, int categoryItemId);
    Task<CategorySelectionModel?> GetCategorySelectionItem(int categoryItemId);
    Task<IEnumerable<CategorySelectionModel>> GetCategorySelections();
    Task<CategorySelectionModel?> GetCategorySelectionStudent(int studentId);
    Task InsertCategorySelection(CategorySelectionModel categorySelection);
    Task UpdateCategorySelection(CategorySelectionModel categorySelection);
}