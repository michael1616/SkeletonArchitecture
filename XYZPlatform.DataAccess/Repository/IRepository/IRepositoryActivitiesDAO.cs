using XYZPlatform.Models.Models;

namespace XYZPlatform.DataAccess.Repository.IRepository
{
    public interface IRepositoryActivitiesDAO
    {
        Task<int> AddActivityDAO(Activity activity);

        Task<List<Activity>> GetActivitysDAO();

        Task<Activity> AddActivityFromRepoDAO(Activity activity);
    }
}
