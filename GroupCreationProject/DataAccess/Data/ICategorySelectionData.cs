using DataAccess.Models;

namespace DataAccess.Data;
public interface ICategorySelectionData
{
    Task DeleteCategorySelection(int studentId, int categoryItemId);
    Task<CategorySelectionModel?> GetCategorySelection(int studentId, int categoryItemId);
    Task<IEnumerable<CategorySelectionModel>> GetCategorySelections();
    Task<IEnumerable<CategorySelectionModel>> GetCategorySelectionsItem(int categoryItemId);
    Task<IEnumerable<CategorySelectionModel>> GetCategorySelectionsStudent(int studentId);
    Task InsertCategorySelection(CategorySelectionModel categorySelection);
    Task UpdateCategorySelection(CategorySelectionModel categorySelection);
}