using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Parkbee.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Parkbee.Application.Garages.Queries.GetGarages
{
    public class GetGarageQuery : IRequest<GarageVm>
    {
        public int Id { get; set; }
    }

    public class GetGarageQueryHandler
        : IRequestHandler<GetGarageQuery, GarageVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGarageQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GarageVm> Handle(
            GetGarageQuery request,
            CancellationToken cancellationToken)
        {

            return new GarageVm
            {
                Garage = await _context.Garages
                                .ProjectTo<GarageDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(cancellationToken)
            };

        }
    }
}
