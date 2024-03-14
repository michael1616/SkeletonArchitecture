using Microsoft.EntityFrameworkCore;
using XYZPlatform.DataAccess.Conection;
using XYZPlatform.DataAccess.Repository.IRepository;
using XYZPlatform.Models.Models;

namespace XYZPlatform.DataAccess.Repository
{
    public class RepositoryActivitiesDAO : Repository<Activity>, IRepositoryActivitiesDAO
    {
        private readonly DBXYZ _db;

        public RepositoryActivitiesDAO(DBXYZ db) : base(db)
        {
            _db = db;
        }

        public async Task<int> AddActivityDAO(Activity activity)
        {
            _db.Activities.Add(activity);
            await _db.SaveChangesAsync();
            return activity.Id;
        }

        public async Task<Activity> AddActivityFromRepoDAO(Activity activity)
        {
            await Add(activity);
            return activity;
        }

        public async Task<List<Activity>> GetActivitysDAO()
        {
            return await _db.Activities.ToListAsync();
        }
    }
}
