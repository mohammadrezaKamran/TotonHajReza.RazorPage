﻿using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Category;

namespace TotonHajReza.RazorPage.Services.Category
{
    public interface ICategoryService
    {
        Task<ApiResult> CreateCategory(CreateCategoryCommand command);
        Task<ApiResult> EditCategory(EditCategoryCommand command);
        Task<ApiResult> DeleteCategory(long categoryId);
        Task<ApiResult> AddChild(AddChildCategoryCommand command);

        Task<CategoryDto?> GetCategoryById(long categoryId);
        Task<List<CategoryDto>> GetCategories();
        Task<List<ChildCategoryDto?>> GetChild(long parentId);
    }
}
