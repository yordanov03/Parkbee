using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Parkbee.Application.Common.Interfaces;
using Parkbee.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parkbee.Application.Garages.Queries.GetGarages
{
    public class GetGarageQuery : IRequest<GarageVm>
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetGarageQueryHandler
        : IRequestHandler<GetGarageQuery, GarageVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDoorApiClient _doorApiClient;

        /// <summary>
        /// The GetGarageQueryHandler constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="doorApiClient"></param>
        public GetGarageQueryHandler(IApplicationDbContext context, IMapper mapper, IDoorApiClient doorApiClient)
        {
            _context = context;
            _mapper = mapper;
            _doorApiClient = doorApiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GarageVm> Handle(
            GetGarageQuery request,
            CancellationToken cancellationToken)
        {
            var myGarage = await _context.Garages
                                .ProjectTo<GarageDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(cancellationToken);

            foreach (var d in myGarage.Doors)
            {
                Status doorStatus = await PingDoorStatusAsync(d.IPAddress);

                if (d.Status != doorStatus)
                {
                    var prevStatus = d.Status;
                    d.Status = doorStatus;

                    await UpdateDoorStatus(d, cancellationToken);

                    await AddDoorStatusEntryToHistory(d, prevStatus);

                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return new GarageVm
            {
                Garage = myGarage
            };

        }

        private async Task UpdateDoorStatus(DoorDto dto, CancellationToken cancellationToken)
        {
            var door = await _context.Doors.FindAsync(new object[] { dto.DoorId });
            door.SetStatus(dto.Status);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task AddDoorStatusEntryToHistory(DoorDto d, Status previusStatus)
        {
            var doorStatusHistory = new DoorStatusHistory
            {
                DoorId = d.DoorId,
                PreviousStatus = previusStatus,
                NewStatus = d.Status,
                TimeOfChange = DateTime.UtcNow
            };

            await _context.DoorStatusHistory.AddAsync(doorStatusHistory);

        }

        private async Task<Status> PingDoorStatusAsync(string iPAddress)
        {
            //_ = await _doorApiClient.GetAsync<int>(iPAddress);

            Random randomDoorStatus = new Random();

            var response = randomDoorStatus.Next(0, 2);

            return (Status)response;
        }
    }
}
