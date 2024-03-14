using Microsoft.EntityFrameworkCore;
using XYZPlatform.DataAccess.Conection;
using XYZPlatform.DataAccess.Repository.IRepository;
using XYZPlatform.Models.Models;

namespace XYZPlatform.DataAccess.Repository
{
    public class RepositoryTimesDAO : Repository<Time>, IRepositoryTimesDAO
    {
        private readonly DBXYZ _db;

        public RepositoryTimesDAO(DBXYZ db) : base(db)
        {
            _db = db;
        }

        public async Task AddTimeDAO(Time time)
        {
            _db.Times.Add(time);
            await _db.SaveChangesAsync();
        }


        public async Task<List<Time>> GetTimesByIdActivityDAO(int idActivity)
        {
            return await _db.Times.Where(a => a.IdActivity == idActivity).ToListAsync();
        }

    }
}
