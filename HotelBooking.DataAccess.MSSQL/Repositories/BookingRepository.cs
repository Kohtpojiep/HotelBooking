using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DataAccess.MSSQL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingHotelsContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(BookingHotelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Booking[]> GetAll()
        {
            var rooms = await _context.Bookings
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Booking[]>(source.Result));
            return rooms;
        }

        public async Task<Booking[]> GetAllWithInclude()
        {
            var rooms = await _context.Bookings
                .Include(x => x.BookingStatus)
                .Include(x => x.BookingAssignedPeople).ThenInclude(x => x.Person)
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Booking[]>(source.Result));
            return rooms;
        }

        public async Task<Booking[]> GetAllByRoomId(int roomId)
        {
            var rooms = await _context.Bookings
                .Where(x => x.RoomId == roomId)
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Booking[]>(source.Result));
            return rooms;
        }

        public async Task<Booking[]> GetAllWithIncludeByRoomId(int roomId)
        {
            var rooms = await _context.Bookings
                .Where(x => x.RoomId == roomId)
                .Include(x => x.BookingStatus)
                .Include(x => x.BookingAssignedPeople).ThenInclude(x => x.Person)
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Booking[]>(source.Result));
            return rooms;
        }

        public async Task<Booking> GetById(int roomId)
        {
            var room = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == roomId)
                .ContinueWith(source => _mapper.Map<Booking>(source.Result)); ;
            return room;
        }

        public async Task<Booking> GetByIdWithInclude(int roomId)
        {
            var room = await _context.Bookings.Where(x => x.Id == roomId)
                .Include(x => x.BookingStatus)
                .Include(x => x.BookingAssignedPeople).ThenInclude(x => x.Person)
                .FirstOrDefaultAsync()
                .ContinueWith(source => _mapper.Map<Booking>(source.Result));
            return room;
        }

        public Booking Add(Booking room)
        {
            var mappedRoom = _mapper.Map<Entities.Booking>(room);
            _context.Bookings.Add(mappedRoom);
            _context.SaveChanges();

            var unmappedRoom = _mapper.Map<Booking>(mappedRoom);
            return unmappedRoom;
        }

        public void Update(Booking room)
        {
            var mappedRoom = _mapper.Map<Entities.Booking>(room);
            _context.Bookings.Update(mappedRoom);
            _context.SaveChanges();
        }

        public void Remove(int roomId)
        {
            var removing = _context.Bookings.First(x => x.Id == roomId);
            _context.Bookings.Remove(removing);
            _context.SaveChanges();
        }
    }
}
