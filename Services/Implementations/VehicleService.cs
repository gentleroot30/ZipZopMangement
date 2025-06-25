using Microsoft.EntityFrameworkCore;
using ZipZop.Data;
using ZipZop.DTO_s;
using ZipZop.dtos;
using ZipZop.Modals;
using ZipZop.Services.Interfaces;

namespace ZipZop.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;

        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetVehicles(GetVehicleFilterDto? filter = null)
        {
            var query = _context.Vehicles.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Type))
                    query = query.Where(v => v.Type == filter.Type);

                if (filter.Available.HasValue)
                    query = query.Where(v => v.Available == filter.Available.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Vehicle> AddVehicle(AddVehicleDto dto)
        {
            var vehicle = new Vehicle
            {
                Brand = dto.Brand,
                Model = dto.Model,
                Type = dto.Type,
                PricePerDay = dto.PricePerDay,
                Available = true
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }


        public async Task<Vehicle?> UpdateVehicle(UpdateVehicleDto v)
        {
            var vehicle = await _context.Vehicles.FindAsync(v.Id);
            if (vehicle == null) return null;

            vehicle.Brand = v.Brand;
            vehicle.Model = v.Model;
            vehicle.PricePerDay = v.PricePerDay;
            vehicle.Type = v.Type;
            vehicle.Available = v.Available;

            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
