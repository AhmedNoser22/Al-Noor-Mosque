namespace Al_Noor.Infrastructure.UnitOfWork
{
    public interface IUnitOF_Work:IDisposable
    {
        IGenericRepo<Activity> GetRepoActivity { get; }
        IGenericRepo<Award> GetRepoAward { get; }
        IGenericRepo<Child> GetRepoChild { get; }
        IGenericRepo<Young> GetRepoYoung { get; }
        IGenericRepo<Teacher> GetRepoTeacher { get; }
        IGenericRepo<Worker> GetRepoWorker { get; }
        Task<bool> Complete();

    }
}
