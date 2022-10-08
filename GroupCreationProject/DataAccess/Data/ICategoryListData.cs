using DataAccess.Models;

namespace DataAccess.Data;
public interface ICategoryListData
{
    Task DeleteCategoryList(int id);
    Task<CategoryListModel?> GetCategoryList(int id);
    Task<IEnumerable<CategoryListModel>> GetCategoryLists();
    Task InsertCategoryList(CategoryListModel categoryList);
    Task UpdateCategoryList(CategoryListModel categoryList);
}