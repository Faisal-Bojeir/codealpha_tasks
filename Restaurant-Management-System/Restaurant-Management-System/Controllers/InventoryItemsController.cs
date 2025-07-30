using Event_Registration_System.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Application.UseCase.InventoryItem;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Dtos;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Parameters;
using Route = Restaurant_Management_System.Application.Common.Constants.InventoryItemRoutes;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InventoryItemsController : BaseController
    {
        private readonly IInventoryItemManagement _management;

        public InventoryItemsController(IInventoryItemManagement management)
        {
            _management = management;
        }

        [HttpPost(Route.Add)]
        public async Task<IActionResult> Add([FromBody] CreateInventoryItemDto dto)
        {
            var result = await _management.AddNewInventoryItem(dto);
            return Result(result);
        }

        [HttpGet(Route.Get)]
        public async Task<IActionResult> Get([FromQuery] InventoryItemQueryParameters parameters)
        {
            var result = await _management.GetInventoryItems(parameters);
            return Result(result);
        }

        [HttpPut(Route.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateInventoryItemDto dto)
        {
            var result = await _management.UpdateInventoryItem(id, dto);
            return Result(result);
        }

        [HttpDelete(Route.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _management.DeleteInventoryItem(id);
            return Result(result);
        }
    }

}
