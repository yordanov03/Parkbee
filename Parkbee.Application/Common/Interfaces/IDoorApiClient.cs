using System.Threading.Tasks;

namespace Parkbee.Application.Common.Interfaces
{
    public interface IDoorApiClient
    {
        Task<T> GetAsync<T>(string ipAddress);
    }
}