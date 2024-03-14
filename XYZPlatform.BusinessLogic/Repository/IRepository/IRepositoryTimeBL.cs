using XYZPlatform.Models.DTO;
using XYZPlatform.Models.Models;

namespace XYZPlatform.BusinessLogic.Repository.IRepository
{
    public interface IRepositoryTimeBL
    {
        Task<List<Time>> GetTimesByActivity(int idActivity);

        Task<string> AddTime(TimeDTO time);

        Task<bool> AddData(ActivityDTO data);
    }
}
