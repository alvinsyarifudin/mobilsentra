using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobilsentra.Controllers.Resources;
using mobilsentra.Core.Models;
using mobilsentra.Persistence;

namespace mobilsentra.Controllers
{
    public class MakesController : Controller
    {
        private readonly MobilSentraDbContext db;
        private readonly IMapper mapper;

        public MakesController(MobilSentraDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes= await db.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
    }
}