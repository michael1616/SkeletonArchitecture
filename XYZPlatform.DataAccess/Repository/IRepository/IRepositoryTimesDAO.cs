using XYZPlatform.Models.Models;

namespace XYZPlatform.DataAccess.Repository.IRepository
{
    public interface IRepositoryTimesDAO
    {
        Task AddTimeDAO(Time time);

        Task<List<Time>> GetTimesByIdActivityDAO(int idActivity);
    }
}
