using AutoMapper;
using Parkbee.Application.Common.Mappings;
using Parkbee.Domain.Entities;

namespace Parkbee.Application.Garages.Queries.GetGarages
{
    public class DoorDto : IMapFrom<Door>
    {
        public int DoorId { get; set; }

        public int GarageId { get; set; }

        public string IPAddress { get; set; }

        //public Garage Garage { get; set; }

        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Door, DoorDto>()
                .ForMember(d => d.DoorId, opt => opt.MapFrom(s => s.DoorId))
                .ForMember(d => d.GarageId, opt => opt.MapFrom(s => s.GarageId))
                .ForMember(d => d.IPAddress, opt => opt.MapFrom(s => s.IPAddress));


            //profile.CreateMap<DoorDto, Door>()
            //    .ForMember(d => d.DoorId, opt => opt.MapFrom(s => s.DoorId))
            //    .ForMember(d => d.GarageId, opt => opt.MapFrom(s => s.GarageId))
            //    .ForMember(d => d.IPAddress, opt => opt.MapFrom(s => s.IPAddress));
            //.ForMember(d => d.Status, opt =>
            //    opt.MapFrom(s => StatusChange(s.Status)));
        }

        //private int StatusChange(int v)
        //{
        //    (int)s.SetStatus(s.Status);
        //}
    }
}
