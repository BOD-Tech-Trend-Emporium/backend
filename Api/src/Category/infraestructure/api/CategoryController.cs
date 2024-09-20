﻿using Api.src.Category.application.mappers;
using Api.src.Category.domain.dto;
using Api.src.Category.domain.repository;
using backend.src.User.domain.enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.src.Category.infraestructure.api
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryRepository _categoryService;

        public CategoryController(CategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CategoryDto>))]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllApprovedAsync();
            var categoriesList = categories.Select(i => i.ToCategoryDto());
            return Ok(categoriesList);
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Employee)}")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto category)
        {
            var result = await _categoryService.CreateAsync(category.ToCategoryModelForCreate());
            return Created($"/api/category/{result.Id}", result.ToCategoryDto());
        }
    }
}
