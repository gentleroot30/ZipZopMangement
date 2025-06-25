using Microsoft.AspNetCore.Mvc;
using ZipZop.Common;
using ZipZop.DTO_s;
using ZipZop.dtos;
using ZipZop.Modals;
using ZipZop.Services.Interfaces;

namespace ZipZop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetVehicles([FromBody] GetVehicleFilterDto? filter)
        {
            var vehicles = await _vehicleService.GetVehicles(filter);
            return Ok(new ApiResponse<List<Vehicle>>(vehicles));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleDto dto)
        {
            var savedVehicle = await _vehicleService.AddVehicle(dto);

            var result = new RecordResultDto
            {
                Id = savedVehicle.Id,
                Message = ResponseMessages.VehicleAdded
            };

            return StatusCode(ResponseMessages.VehicleAddedCode, new ApiResponse<RecordResultDto>(result, ResponseMessages.VehicleAdded));
        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleDto dto)
        {
            if (dto == null)
                return BadRequest(new ApiErrorResponse(ResponseMessages.InvalidInput, ResponseMessages.InvalidInputCode));

            var updatedVehicle = await _vehicleService.UpdateVehicle(dto);
            if (updatedVehicle == null)
                return NotFound(new ApiErrorResponse(ResponseMessages.VehicleNotFound, ResponseMessages.VehicleNotFoundCode));

            var result = new RecordResultDto
            {
                Id = updatedVehicle.Id,
                Message = ResponseMessages.VehicleUpdated
            };

            return Ok(new ApiResponse<RecordResultDto>(result, ResponseMessages.VehicleUpdated));
        }





        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _vehicleService.DeleteVehicle(id);
            if (!result)
                return NotFound(new ApiErrorResponse(ResponseMessages.VehicleNotFound, ResponseMessages.VehicleNotFoundCode));

            var response = new RecordResultDto
            {
                Id = id,
                Message = "Vehicle deleted successfully."
            };

            return Ok(new ApiResponse<RecordResultDto>(response, "Vehicle deleted successfully."));
        }
    }

}
