using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IRepositories
{
    public interface IBookingRepository
    {
        Task<Booking[]> GetAll();
        Task<Booking[]> GetAllWithInclude();
        Task<Booking[]> GetAllByRoomId(int roomId);
        Task<Booking[]> GetAllWithIncludeByRoomId(int roomId);
        Task<Booking> GetById(int bookingId);
        Task<Booking> GetByIdWithInclude(int bookingId);
        Booking Add(Booking room);
        void Update(Booking room);
        void Remove(int bookingId);
    }
}