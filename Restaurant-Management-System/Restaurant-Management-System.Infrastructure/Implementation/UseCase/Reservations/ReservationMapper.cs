using Restaurant_Management_System.Application.UseCase.Reservations.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Reservations
{
    public static class ReservationMapper
    {
        public static Reservation MapTo(this CreateReservationDto dto)
        {
            return new()
            {
                CustomerName= dto.CustomerName,
                NumberOfGuests = dto.NumberOfGuests,
                ReservationTime =  dto.ReservationTime,
                Status = Domain.Entities.Enum.enReservationStatus.Pending,
                TableId = dto.TableId,
            };
        }

        public static ReservationDto MapTo(this Reservation reservation)
        {
            return new()
            {
                Id = reservation.Id,
                CustomerName = reservation.CustomerName,
                NumberOfGuests = reservation.NumberOfGuests,
                ReservationTime = reservation.ReservationTime,
                Status = reservation.Status,
                TableId = reservation.TableId,
                TableName = reservation.Table.Number
            };
        }
    }
}
