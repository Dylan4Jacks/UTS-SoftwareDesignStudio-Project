using DataAccess.Models;

namespace DataAccess.Data;
public interface ICategoryItemData
{
    Task DeleteCategoryItem(int id);
    Task<CategoryItemModel?> GetCategoryItem(int id);
    Task<IEnumerable<CategoryItemModel>> GetCategoryItems();
    Task InsertCategoryItem(CategoryItemModel categoryItem);
    Task UpdateCategoryItem(CategoryItemModel categoryItem);
}