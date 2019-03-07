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
    public class FeatureController : Controller
    {
        private readonly MobilSentraDbContext db;
        private readonly IMapper mapper;

        public FeatureController(MobilSentraDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("api/getFeatures")]
        public async Task<IEnumerable<KeyValuePairs>> GetFeature()
        {
            var feature= await db.Features.ToListAsync();            
            return mapper.Map<List<Feature>,List<KeyValuePairs>>(feature);
        }
    }
}