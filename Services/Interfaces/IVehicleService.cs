using ZipZop.DTO_s;
using ZipZop.dtos;
using ZipZop.Modals;

namespace ZipZop.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> AddVehicle(AddVehicleDto dto);
        Task<Vehicle?> UpdateVehicle(UpdateVehicleDto vehicle);
        Task<bool> DeleteVehicle(int id);

        Task<List<Vehicle>> GetVehicles(GetVehicleFilterDto? filter = null);
    }

}