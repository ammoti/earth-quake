using System.Threading.Tasks;
using EarthQuake.Model;

namespace EarthQuake.Application
{
    public interface IAPIService
    {
        Task<ResponseModel> QueryEarthQuakeData(QueryRequestModel model);
        Task<int> USGSPing();
    }
}
