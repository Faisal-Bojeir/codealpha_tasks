using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Application.UseCase.MenuItemInventories;
using Restaurant_Management_System.Application.UseCase.MenuItemInventories.Dtos;
using Route = Restaurant_Management_System.Application.Common.Constants.MenuItemInventoryRoutes;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MenuItemInventoriesController : BaseController
    {
        private readonly IMenuItemInventoryManagement _management;

        public MenuItemInventoriesController(IMenuItemInventoryManagement management)
        {
            _management = management;
        }

        [HttpPost(Route.Add)]
        public async Task<IActionResult> Add([FromBody] CreateMenuItemInventoryDto dto)
        {
            var response = await _management.AddMenuItemInventory(dto);
            return Result(response);
        }

        [HttpPut(Route.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMenuItemInventoryDto dto)
        {
            var response = await _management.UpdateMenuItemInventory(id, dto);
            return Result(response);
        }

        [HttpDelete(Route.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _management.DeleteMenuItemInventory(id);
            return Result(response);
        }

        [HttpGet(Route.GetByMenuItemId)]
        public async Task<IActionResult> GetByMenuItemId([FromRoute] int menuItemId, [FromQuery] MenuItemInventoryQueryParameter parameter)
        {
            var response = await _management.GetByMenuItemId(menuItemId, parameter);
            return Result(response);
        }

    }

}
