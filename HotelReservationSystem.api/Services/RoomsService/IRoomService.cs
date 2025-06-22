using HotelReservationSystem.api.Contracts.Rooms;

namespace HotelReservationSystem.api.Services.RoomsService
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<RoomResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<RoomResponse>> AddAsync(RoomRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int id, RoomRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
