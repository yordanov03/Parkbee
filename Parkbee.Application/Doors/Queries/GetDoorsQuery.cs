using MediatR;
using Parkbee.Domain.Entities;
using System.Collections.Generic;

namespace Parkbee.Application.Doors.Queries
{
    public class GetDoorsQuery : IRequest<List<Door>>
    {
    }
}
