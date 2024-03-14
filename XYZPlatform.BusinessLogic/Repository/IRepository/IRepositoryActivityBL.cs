using XYZPlatform.Models.DTO;
using XYZPlatform.Models.Models;

namespace XYZPlatform.BusinessLogic.Repository.IRepository
{
    public interface IRepositoryActivityBL
    {
        public Task<List<Activity>> GetAllActivities();

        public Task<bool> AddActivity(ActivityDTO activity);

        public Task<int> AddActivityFromRepository(ActivityDTO activity);
    }
}
