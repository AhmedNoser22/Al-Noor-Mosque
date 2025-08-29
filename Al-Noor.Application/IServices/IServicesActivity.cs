namespace Al_Noor.Application.IServices
{
    public interface IServicesActivity
    {
        Task<IEnumerable<ActivityDto>> GetActivityDtos();
    }
}
