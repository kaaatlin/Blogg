﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLog.BLL.Services.IServices;
using BLog.BLL.ViewModels.Roles;
using BLog.DAL.Models;

namespace BLog.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение всех ролей
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetRoles")]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _roleService.GetRoles();

            return roles;
        }

        /// <summary>
        /// Добавление роли
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleCreateViewModel model)
        {
            await _roleService.CreateRole(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование роли
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole(RoleEditViewModel model)
        {
            await _roleService.EditRole(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveRole")]
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            await _roleService.RemoveRole(id);

            return StatusCode(201);
        }
    }
}
