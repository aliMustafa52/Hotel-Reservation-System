namespace HotelReservationSystem.api.Services.FacilitiesService
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<FacilityResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<FacilityResponse>> AddAsync(FacilityRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int id, FacilityRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
