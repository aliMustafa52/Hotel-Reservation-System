namespace HotelReservationSystem.api.Contracts.Facilities
{
    public class FacilityRequestValidator : AbstractValidator<FacilityRequest>
    {
        public FacilityRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 100);
        }
    }
}
