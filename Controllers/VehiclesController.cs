using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobilsentra.Controllers.Resources;
using mobilsentra.Core;
using mobilsentra.Core.Models;
using mobilsentra.Persistence;

namespace mobilsentra.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {        
        private readonly IMapper map;
        private readonly IVehicleRepository repos;
        private readonly IUnitOfWork uow;

        public VehiclesController(            
            IMapper map,
            IVehicleRepository repos,
            IUnitOfWork uow)
        {            
            this.map = map;
            this.repos = repos;
            this.uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResources vehicle)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                        
            var res=map.Map<SaveVehicleResources,Vehicle>(vehicle);               
            res.LastUpdate=DateTime.Now;

            repos.Add(res);            
            await uow.Complete();

            var result=await repos.GetVehicle(vehicle.Id);

            var respond=map.Map<Vehicle,VehicleResources>(result);
            return Ok(respond);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody]SaveVehicleResources vehicle)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);                     
            
           var vData=await repos.GetVehicle(vehicle.Id);
            if(vData == null)
                return NotFound();

            map.Map<SaveVehicleResources,Vehicle>(vehicle,vData);               
            vData.LastUpdate=DateTime.Now;
            
            await uow.Complete();

            vData = await repos.GetVehicle(vehicle.Id);                            
            var respond=map.Map<Vehicle,VehicleResources>(vData);
            return Ok(respond);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
          
           var vehicle= await repos.GetVehicle(id,includeRelated:false);
           if(vehicle == null)
            return NotFound();
           
           repos.Remove(vehicle);
            await uow.Complete();

           return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle (int id)
        {
            var data=await repos.GetVehicle(id);
            if(data == null)
                return NotFound();

            var res = map.Map<Vehicle,VehicleResources>(data);

            return Ok(res);
        }
    }
}