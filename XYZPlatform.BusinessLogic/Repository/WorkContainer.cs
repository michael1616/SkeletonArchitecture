using XYZPlatform.BusinessLogic.Repository.IRepository;
using XYZPlatform.DataAccess.Conection;
using XYZPlatform.DataAccess.Repository;

namespace XYZPlatform.BusinessLogic.Repository
{
    public class WorkContainer : IWorkContainer
    {
        private readonly DBXYZ _db;

        public IRepositoryActivityBL Activity { get; set; }

        public IRepositoryTimeBL Time { get; set; }


        public WorkContainer(DBXYZ db)
        {
            _db = db;
            RepositoryActivitiesDAO repoActiviDAO = new RepositoryActivitiesDAO(_db);
            RepositoryTimesDAO repoTimeDAO = new RepositoryTimesDAO(_db);


            Activity = new RepositoryActivityBL(repoActiviDAO);
            Time = new RepositoryTimeBL(repoTimeDAO, repoActiviDAO);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }
    }
}
