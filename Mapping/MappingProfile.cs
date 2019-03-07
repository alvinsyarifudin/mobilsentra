using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using mobilsentra.Controllers.Resources;
using mobilsentra.Core.Models;

namespace mobilsentra.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make,MakeResource>();
            CreateMap<Make,KeyValuePairs>();
            CreateMap<Model,KeyValuePairs>();
            CreateMap<Feature,KeyValuePairs>();
            CreateMap<Vehicle,SaveVehicleResources>()
                .ForMember(vr => vr.Contact,opt => opt.MapFrom(v => new ContactResource{
                    Name=v.ContactName,
                    Email=v.contactEmail,
                    Phone=v.ContactPhone
                    })
                )
                .ForMember(vr => vr.Features,opt => opt.MapFrom(
                    v => v.Features
                        .Select(vf => vf.FeatureId))
                );
             CreateMap<Vehicle,VehicleResources>()
                  .ForMember(vr => vr.Contact,opt => opt.MapFrom(v => new ContactResource{
                    Name=v.ContactName,
                    Email=v.contactEmail,
                    Phone=v.ContactPhone
                    })
                )
                .ForMember( vr => vr.Make,opt => opt.MapFrom(v=>v.Model.Make))
                .ForMember(vr => vr.Features,opt => opt.MapFrom(
                    v => v.Features
                        .Select(vf => new KeyValuePairs { Id = vf.Feature.Id,Name = vf.Feature.Name}))
                );

            //API Resource to Domain
            CreateMap<SaveVehicleResources,Vehicle>()
                .ForMember(v => v.Id,opt=>opt.Ignore())
                .ForMember(v => v.ContactName,opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.contactEmail,opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone,opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features,opt => opt.Ignore())
                .AfterMap((vr,v)=>{                       
                        //remove feaature                       
                        var removedFeature=v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                        foreach(var f in removedFeature)
                            v.Features.Remove(f);

                        //add feature
                        var addedFeatures=vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id))
                            .Select(id => new VehicleFeature {
                                FeatureId=id
                            });
                        foreach(var f in addedFeatures)                            
                            v.Features.Add(f);
                        
                });                          
        }
    }
}