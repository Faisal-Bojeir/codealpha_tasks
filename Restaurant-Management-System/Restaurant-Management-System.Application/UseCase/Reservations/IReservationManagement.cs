using Event_Registration_System.Application.Common;
using Restaurant_Management_System.Application.UseCase.Reservations.Dtos;
using Restaurant_Management_System.Application.UseCase.Reservations.Parameters;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Reservations
{
    public interface IReservationManagement
    {
        Task<ApiResponse> AddNewReservate(CreateReservationDto dto);
        Task<ApiResponse> GetReservationsInfo(ReservationQueryParameters parameters);
        Task<ApiResponse> UpdateReservationInfo(int id, UpdateReservationInfoDto dto);
    }
}
