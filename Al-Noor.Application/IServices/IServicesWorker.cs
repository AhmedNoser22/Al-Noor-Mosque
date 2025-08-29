namespace Al_Noor.Application.IServices
{
    public interface IServicesWorker
    {
        Task<IEnumerable<WorkerDto>> GetWorkerDtosAllAsync();
        Task<WorkerDto> GetWorkerDtoByIdAsync(int id);
        Task<WorkerDto> CreateWorkerDtoAsync(WorkerDto workerDto);
    }
}
