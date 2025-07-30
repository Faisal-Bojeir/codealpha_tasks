using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.MenuItem;
using Restaurant_Management_System.Application.UseCase.MenuItem.Dtos;
using Restaurant_Management_System.Controllers;
using Route = Restaurant_Management_System.Application.Common.Constants.MenuItemsRoutes;

namespace Restaurant_Management_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : BaseController
    {
        private readonly IMenuItemManagement _menuItemManagement;

        public MenuItemsController(IMenuItemManagement menuItemManagement)
        {
            _menuItemManagement = menuItemManagement;
        }

        [HttpGet(Route.GetMenus)]
        public async Task<IActionResult> GetMenus([FromQuery] MenuItemQueryParameters parameters)
        {
            var response = await _menuItemManagement.GetMenus(parameters);
            return Result(response);
        }

        [HttpGet(Route.GetMenuById)]
        public async Task<IActionResult> GetMenuById([FromRoute] int id)
        {
            var response = await _menuItemManagement.GetMenuById(id);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Route.AddNewMenu)]
        public async Task<IActionResult> AddNewMenu([FromBody] CreateMenuItemDto dto)
        {
            var response = await _menuItemManagement.CreateMenuItem(dto);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Route.UpdateMenu)]
        public async Task<IActionResult> UpdateMenu([FromBody] UpdateMenuItemDto dto)
        {
            var response = await _menuItemManagement.UpdateMenuItem(dto);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(Route.DeleteMenu)]
        public async Task<IActionResult> DeleteMenu([FromRoute] int id)
        {
            var response = await _menuItemManagement.DeleteMenuItem(id);
            return Result(response);
        }
    }
}

