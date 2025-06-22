﻿namespace HotelReservationSystem.api.Contracts.RoomTypes
{
    public class RoomTypeRequestValidator : AbstractValidator<RoomTypeRequest>
    {
        public RoomTypeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 1000);
        }
    }
}
