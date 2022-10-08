using DataAccess.Models;

namespace DataAccess.Data;
public interface ICategorySelectionData
{
    Task DeleteCategorySelection(int categoryItemId, int studentId);
    Task<CategorySelectionModel?> GetCategorySelection(int categoryItemId, int studentId);
    Task<IEnumerable<CategorySelectionModel>> GetCategorySelections();
    Task InsertCategorySelection(CategorySelectionModel categorySelection);
    Task UpdateCategorySelection(CategorySelectionModel categorySelection);
}