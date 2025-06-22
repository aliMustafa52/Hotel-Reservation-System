﻿using HotelReservationSystem.api.Abstractions;
using HotelReservationSystem.api.Contracts.RoomTypes;
using HotelReservationSystem.api.Services.RoomTypeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController(IRoomTypeService roomTypeService) : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService = roomTypeService;

        [HttpGet("")]
        public async Task<IActionResult> GetAllRoomTypes(CancellationToken cancellationToken)
        {
            var roomTypes = await _roomTypeService.GetAllAsync(cancellationToken);
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypeById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _roomTypeService.GetByIdAsync(id, cancellationToken);

            return result.IsSuccess
                ? Ok(result.Value)
                : result.ToProblem();
        }

        [HttpPost("")]
        public async Task<IActionResult> AddRoomType([FromBody] RoomTypeRequest request, CancellationToken cancellationToken)
        {
            var result = await _roomTypeService.AddAsync(request, cancellationToken);

            return result.IsSuccess
                ? CreatedAtAction(nameof(GetRoomTypeById), new { id = result.Value.Id }, request)
                : result.ToProblem();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomType([FromRoute] int id, [FromBody] RoomTypeRequest request, CancellationToken cancellationToken)
        {
            var result = await _roomTypeService.UpdateAsync(id, request, cancellationToken);

            return result.IsSuccess
                ? NoContent()
                : result.ToProblem();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _roomTypeService.DeleteAsync(id, cancellationToken);

            return result.IsSuccess
                ? NoContent()
                : result.ToProblem();
        }
    }
}
