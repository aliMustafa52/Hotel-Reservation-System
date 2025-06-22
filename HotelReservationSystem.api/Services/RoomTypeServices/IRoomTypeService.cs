using HotelReservationSystem.api.Contracts.RoomTypes;

namespace HotelReservationSystem.api.Services.RoomTypeServices
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<RoomTypeResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<RoomTypeResponse>> AddAsync(RoomTypeRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int id, RoomTypeRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
