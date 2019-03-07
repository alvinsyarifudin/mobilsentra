using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobilsentra.Core;
using mobilsentra.Core.Models;

namespace mobilsentra.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MobilSentraDbContext db;

        public VehicleRepository(MobilSentraDbContext db)
        {
            this.db = db;
        }

        public void Add(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            db.Vehicles.Remove(vehicle);
        }
     
        public async Task<Vehicle> GetVehicle(int id,bool includeRelated = true)
        {
            if(!includeRelated)
                return await db.Vehicles.FindAsync(id);
             return await db.Vehicles.Include(f => f.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}