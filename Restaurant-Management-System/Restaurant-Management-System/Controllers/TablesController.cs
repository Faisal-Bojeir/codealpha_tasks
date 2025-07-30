using Event_Registration_System.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Application.UseCase.Tables;
using Restaurant_Management_System.Application.UseCase.Tables.Dtos;
using Restaurant_Management_System.Application.UseCase.Tables.Parameters;
using Route = Restaurant_Management_System.Application.Common.Constants.TableRoutes;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : BaseController
    {
        private readonly ITableManagement _management;

        public TableController(ITableManagement management)
        {
            _management = management;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Route.Add)]
        public async Task<IActionResult> Add([FromBody] CreateTableDto dto)
        {
            var response = await _management.AddNewTable(dto);
            return Result(response);
        }

        [HttpGet(Route.Get)]
        public async Task<IActionResult> Get([FromQuery] TableQueryParameters parameters)
        {
            var response = await _management.GetTables(parameters);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Route.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTableDto dto)
        {
            var response = await _management.UpdateTable(id, dto);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(Route.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _management.RemoveTable(id);
            return Result(response);
        }
    }

}
