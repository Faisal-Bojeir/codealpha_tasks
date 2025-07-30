using Event_Registration_System.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.Reservations;
using Restaurant_Management_System.Application.UseCase.Reservations.Dtos;
using Restaurant_Management_System.Application.UseCase.Tables;
using Restaurant_Management_System.Application.UseCase.Tables.Parameters;
using Restaurant_Management_System.Controllers;
using Route = Restaurant_Management_System.Application.Common.Constants.ReservationRoutes;

namespace Restaurant_Management_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : BaseController
    {
        private readonly IReservationManagement _reservationManagement;
        private readonly ITableManagement _tableManagement;

        public ReservationsController(IReservationManagement reservationManagement, ITableManagement tableManagement)
        {
            _reservationManagement = reservationManagement;
            _tableManagement = tableManagement;
        }

        [HttpGet(Route.GetAllTables)]
        public async Task<IActionResult> GetAllTables([FromQuery] TableQueryParameters parameters)
        {
            var response = await _tableManagement.GetTables(parameters);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Route.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateReservationInfoDto dto)
        {
            var result = await _reservationManagement.UpdateReservationInfo(id, dto);
            return Result(result);
        }

        [HttpPost(Route.AddNewReservation)]
        public async Task<IActionResult> AddNewReservation([FromBody] CreateReservationDto dto)
        {
            var response = await _reservationManagement.AddNewReservate(dto);
            return Result(response);
        }
    }
}
