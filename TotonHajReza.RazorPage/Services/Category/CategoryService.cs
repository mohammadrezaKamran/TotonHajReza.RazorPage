﻿using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Category;

namespace TotonHajReza.RazorPage.Services.Category
{
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync("category", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _client.PutAsJsonAsync("category", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteCategory(long categoryId)
        {
            var result = await _client.DeleteAsync($"category/{categoryId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> AddChild(AddChildCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync("category/AddChild", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<CategoryDto?> GetCategoryById(long categoryId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CategoryDto>>($"category/{categoryId}");
            return result?.Data;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<CategoryDto>>>($"category");
            return result?.Data;
        }

        public async Task<List<ChildCategoryDto?>> GetChild(long parentId)
        {
            var result = await _client
                .GetFromJsonAsync<ApiResult<List<ChildCategoryDto>>>($"category/getChild/{parentId}");
            return result?.Data;
        }
    }
}
