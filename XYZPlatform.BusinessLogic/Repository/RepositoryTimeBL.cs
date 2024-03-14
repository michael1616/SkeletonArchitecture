using XYZPlatform.BusinessLogic.Repository.IRepository;
using XYZPlatform.DataAccess.Repository.IRepository;
using XYZPlatform.Models.DTO;
using XYZPlatform.Models.Models;

namespace XYZPlatform.BusinessLogic.Repository
{
    public class RepositoryTimeBL : IRepositoryTimeBL
    {
        private readonly IRepositoryTimesDAO _repositoryTimeDAO;
        private readonly IRepositoryActivitiesDAO _repositoryActivityDAO;

        public RepositoryTimeBL(IRepositoryTimesDAO repositoryTimeDAO, IRepositoryActivitiesDAO repositoryActivityDAO)
        {
            _repositoryTimeDAO = repositoryTimeDAO;
            _repositoryActivityDAO = repositoryActivityDAO;
        }

        public async Task<List<Time>> GetTimesByActivity(int idActivity)
        {
            return await _repositoryTimeDAO.GetTimesByIdActivityDAO(idActivity);
        }

        public async Task<string> AddTime(TimeDTO time)
        {
            if (time.Hour <= 0)
            {
                return "La hora no es correcta";
            }

            List<Time> litsActivities = await _repositoryTimeDAO.GetTimesByIdActivityDAO(time.IdActivity);
            int totalHoursInDB = litsActivities.Sum(x => x.Hour);
            int totalHours = (totalHoursInDB + time.Hour);

            if (totalHours > 8)
            {
                return "Esta actividad tiene mas de 8 horas";
            }
            else
            {
                Time timeDB = new Time()
                {
                    DateActivity = time.DateActivity,
                    Hour = time.Hour,
                    IdActivity = time.IdActivity
                };

                await _repositoryTimeDAO.AddTimeDAO(timeDB);
                return "Ok";
            }

        }

        public async Task<bool> AddData(ActivityDTO data)
        {
            Models.Models.Activity activityDB = new Models.Models.Activity()
            {
                Name = data.Name
            };

            int idActivity = await _repositoryActivityDAO.AddActivityDAO(activityDB);


            Time timeDB = new Time()
            {
                DateActivity = data.Time.DateActivity,
                Hour = data.Time.Hour,
                IdActivity = idActivity
            };

            await _repositoryTimeDAO.AddTimeDAO(timeDB);


            return true;
        }
    }
}
