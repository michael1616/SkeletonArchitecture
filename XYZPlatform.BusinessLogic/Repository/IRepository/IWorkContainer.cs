namespace XYZPlatform.BusinessLogic.Repository.IRepository
{
    public interface IWorkContainer : IDisposable
    {
        IRepositoryActivityBL Activity { get; }

        IRepositoryTimeBL Time { get; }

        Task SaveAsync();
    }
}
