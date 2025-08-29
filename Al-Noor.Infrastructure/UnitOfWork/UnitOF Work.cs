namespace Al_Noor.Infrastructure.UnitOfWork
{
    public class UnitOF_Work : IUnitOF_Work
    {
        private readonly AppDbContext _context;
        public IGenericRepo<Activity> GetRepoActivity { get; private set; }
        public IGenericRepo<Award> GetRepoAward { get; private set; }
        public IGenericRepo<Child> GetRepoChild { get; private set; }
        public IGenericRepo<Young> GetRepoYoung { get; private set; }
        public IGenericRepo<Teacher> GetRepoTeacher { get; private set; }
        public IGenericRepo<Worker> GetRepoWorker { get; private set; }
        public UnitOF_Work(AppDbContext context)
        {
            _context = context;
            GetRepoActivity = new GenericRepo<Activity>(_context);
            GetRepoAward = new GenericRepo<Award>(_context);
            GetRepoChild = new GenericRepo<Child>(_context);
            GetRepoYoung = new GenericRepo<Young>(_context);
            GetRepoTeacher = new GenericRepo<Teacher>(_context);
            GetRepoWorker = new GenericRepo<Worker>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
