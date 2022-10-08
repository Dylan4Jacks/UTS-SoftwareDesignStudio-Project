using DataAccess.Models;

namespace DataAccess.Data;
public interface ICategorySelectionData
{
    Task DeleteCategorySelection(int id);
    Task<CategorySelectionModel?> GetCategorySelection(int id);
    Task<IEnumerable<CategorySelectionModel>> GetCategorySelections();
    Task InsertCategorySelection(CategorySelectionModel categorySelection);
    Task UpdateCategorySelection(CategorySelectionModel categorySelection);
}