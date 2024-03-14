using XYZPlatform.BusinessLogic.Repository.IRepository;
using XYZPlatform.DataAccess.Repository.IRepository;
using XYZPlatform.Models.DTO;
using XYZPlatform.Models.Models;

namespace XYZPlatform.BusinessLogic.Repository
{
    public class RepositoryActivityBL : IRepositoryActivityBL
    {
        private readonly IRepositoryActivitiesDAO _repositoryActivityDAO;

        public RepositoryActivityBL(IRepositoryActivitiesDAO repositoryActivityDAO)
        {
            _repositoryActivityDAO = repositoryActivityDAO;
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            return await _repositoryActivityDAO.GetActivitysDAO();
        }

        public async Task<bool> AddActivity(ActivityDTO activity)
        {
            Activity activityDB = new Activity()
            {
                Name = activity.Name
            };

            var reuslt = await _repositoryActivityDAO.AddActivityDAO(activityDB);

            return reuslt > 0 ? true : false;
        }

        public async Task<int> AddActivityFromRepository(ActivityDTO activity)
        {
            Activity activityDB = new Activity()
            {
                Name = activity.Name
            };

            Activity entitie = await _repositoryActivityDAO.AddActivityFromRepoDAO(activityDB);

            return entitie.Id;
        }
    }
}
