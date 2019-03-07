using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mobilsentra.Core.Models;

namespace mobilsentra.Core
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id,bool includeRelated = true);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);

    }
}