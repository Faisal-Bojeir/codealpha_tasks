using Event_Registration_System.Application.Common;
using LinqKit;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.Reservations;
using Restaurant_Management_System.Application.UseCase.Reservations.Dtos;
using Restaurant_Management_System.Application.UseCase.Reservations.Parameters;
using Restaurant_Management_System.Application.UseCase.Tables;
using Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Reservations
{
    public class ReservationManagement : IReservationManagement
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationManagement(
            IReservationRepository reservationRepository,
            ITableRepository tableRepository
            )
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
        }

        public async Task<ApiResponse> AddNewReservate(CreateReservationDto dto)
        {
            var table = await _tableRepository.GetTableAvailabilityAsync(dto.TableId);

            if (table is null)
                return ApiResponse.Fail("Table is not found.");

            if (table.IsAvailable == false)
                return ApiResponse.Fail("Table is not available right now.");

            if (dto.NumberOfGuests > table.Seats)
                return ApiResponse.Fail("Number of guests exceeds the number of available seats at the table.");

            var Reservation = dto.MapTo();
            await _reservationRepository.CreateAsync(Reservation);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> GetReservationsInfo(ReservationQueryParameters parameters)
        {
            Expression<Func<Reservation, bool>> condition = r => true;

            if (parameters.TableId.HasValue)
                condition = condition.And(r => r.TableId == parameters.TableId.Value);

            if (!string.IsNullOrWhiteSpace(parameters.CustomerName))
                condition = condition.And(r => r.CustomerName.ToLower().StartsWith(parameters.CustomerName.ToLower()));

            if (parameters.From.HasValue)
                condition = condition.And(r => r.ReservationTime >= parameters.From.Value);

            if (parameters.To.HasValue)
                condition = condition.And(r => r.ReservationTime <= parameters.To.Value);

            if (parameters.Status.HasValue)
                condition = condition.And(r => r.Status == parameters.Status.Value);

            if (parameters.MinGuests.HasValue)
                condition = condition.And(r => r.NumberOfGuests >= parameters.MinGuests.Value);

            if (parameters.MaxGuests.HasValue)
                condition = condition.And(r => r.NumberOfGuests <= parameters.MaxGuests.Value);

            var query = await _reservationRepository.GetRangeByConditionAsync(
                condition,
                parameters,
                cancellationToken: default,
                i => i.Table
            );
            var response = query.Map(q => q.MapTo());
            return ApiResponse.Success(response);
        }

        public async Task<ApiResponse> UpdateReservationInfo(int id, UpdateReservationInfoDto dto)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation is null)
                return ApiResponse.Fail("Reservation not found");

            var table = await _tableRepository.GetByIdAsync(id);
            
            if (table is null)
                return ApiResponse.Fail("Table is not found.");

            if (dto.Status == enReservationStatus.Confirmed || dto.Status == enReservationStatus.Pending)
            {
                table.IsAvailable = false;
            }
            else
            {
                table.IsAvailable = true;
            }

            reservation.Status = dto.Status;
            await _tableRepository.UpdateAsync(table);
            await _reservationRepository.UpdateAsync(reservation);
            return ApiResponse.Success(null);
        }
    }
}
