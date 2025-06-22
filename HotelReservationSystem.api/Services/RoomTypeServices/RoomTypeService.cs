using Azure;
using Azure.Core;
using HotelReservationSystem.api.Contracts.RoomTypes;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.api.Services.RoomTypeServices
{
    public class RoomTypeService(IGeneralRepository<RoomType> roomTypeRepository,
        IGeneralRepository<Room> roomRepository) : IRoomTypeService
    {
        private readonly IGeneralRepository<RoomType> _roomTypeRepository = roomTypeRepository;
        private readonly IGeneralRepository<Room> _roomRepository = roomRepository;

        public async Task<IEnumerable<RoomTypeResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var roomTypes = await _roomTypeRepository.Get(rt => rt.IsActive)
                .ToListAsync(cancellationToken);

            return roomTypes.Adapt<IEnumerable<RoomTypeResponse>>();
        }

        public async Task<Result<RoomTypeResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var roomType = await _roomTypeRepository.Get(rt => rt.Id == id && rt.IsActive)
                    .SingleOrDefaultAsync(cancellationToken);
            if (roomType is null)
                return Result.Failure<RoomTypeResponse>(RoomTypeErrors.NotFound);

            var response = roomType.Adapt<RoomTypeResponse>();
            return Result.Success(response);
        }

        public async Task<Result<RoomTypeResponse>> AddAsync(RoomTypeRequest request, CancellationToken cancellationToken = default)
        {
            var isRoomTypeExists = await _roomTypeRepository.AnyAsync(rt => rt.Name == request.Name, cancellationToken);
            if(isRoomTypeExists)
                return Result.Failure<RoomTypeResponse>(RoomTypeErrors.AlreadyExists);

            var roomType = request.Adapt<RoomType>();
            var addedRoomType = await _roomTypeRepository.AddAsync(roomType);

            return Result.Success(addedRoomType.Adapt<RoomTypeResponse>());
        }

        public async Task<Result> UpdateAsync(int id, RoomTypeRequest request, CancellationToken cancellationToken = default)
        {
            var isRoomTypeExists = await _roomTypeRepository.AnyAsync(rt => rt.Name == request.Name && rt.Id != id, cancellationToken);
            if (isRoomTypeExists)
                return Result.Failure(RoomTypeErrors.AlreadyExists);

            var roomType = await _roomTypeRepository.Get(rt => rt.Id == id && rt.IsActive)
                    .SingleOrDefaultAsync(cancellationToken);
            if (roomType is null)
                return Result.Failure(RoomTypeErrors.NotFound);

            await _roomTypeRepository.UpdateAsync(x => x.Id == id,
                s => s
                    .SetProperty(y => y.Name, request.Name)
                    .SetProperty(y => y.Description, request.Description)

                );

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var isRoomTypeInUse = await _roomRepository.AnyAsync(r => r.RoomTypeId == id, cancellationToken);
            if(isRoomTypeInUse)
                return Result.Failure<RoomTypeResponse>(RoomTypeErrors.CannotDeleteBecauseInUse);

            var isDeleted = await _roomTypeRepository.DeleteAsync(id);
            if(!isDeleted)
                return Result.Failure<RoomTypeResponse>(RoomTypeErrors.NotFound);

            return Result.Success();
        }
        
    }
}
