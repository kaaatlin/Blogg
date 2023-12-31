﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLog.BLL.Services.IServices;
using BLog.BLL.ViewModels.Tags;
using BLog.DAL.Models;

namespace BLog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagSerive;

        public TagController(ITagService tagService)
        {
            _tagSerive = tagService;
        }

        /// <summary>
        /// Получение всех тегов
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetTags")]
        public async Task<List<Tag>> GetTags()
        {
            var tags = await _tagSerive.GetTags();

            return tags;
        }

        /// <summary>
        /// Добавление тега
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddTag")]
        public async Task<IActionResult> AddTag(TagCreateViewModel model)
        {
            var result = await _tagSerive.CreateTag(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование тега
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditTag")]
        public async Task<IActionResult> EditTag(TagEditViewModel model)
        {
            await _tagSerive.EditTag(model, model.Id);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление тега
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveTag")]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            await _tagSerive.RemoveTag(id);

            return StatusCode(201);
        }
    }
}
