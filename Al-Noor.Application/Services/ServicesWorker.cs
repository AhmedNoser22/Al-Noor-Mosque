namespace Al_Noor.Application.Services
{
    public class ServicesWorker
        (IUnitOF_Work work , IMapper mapper): IServicesWorker
    {
        public async Task<IEnumerable<WorkerDto>> GetWorkerDtosAllAsync()
        {
            var workers = await work.GetRepoWorker.GetAllAsync();
            return mapper.Map<IEnumerable<WorkerDto>>(workers);
        }
        public async Task<WorkerDto> GetWorkerDtoByIdAsync(int id)
        {
            var worker = await work.GetRepoWorker.GetByIdAsync(id);
            if (worker == null)
            {
                throw new KeyNotFoundException($"Worker with ID {id} not found.");
            }
            return mapper.Map<WorkerDto>(worker);
        }
        public async Task<WorkerDto> CreateWorkerDtoAsync(WorkerDto workerDto)
        {
            if (workerDto == null)
            {
                throw new ArgumentNullException(nameof(workerDto), "WorkerDto cannot be null.");
            }
            var worker = mapper.Map<Worker>(workerDto);
            var item = await work.GetRepoWorker.AddAsync(worker);
            await work.Complete();
            return mapper.Map<WorkerDto>(item);
        }
    }
}
