namespace Al_Noor.Application.IServices
{
    public interface IServicesAward
    {
        Task<IEnumerable<AwardDto>> GetAllAwardDtosAsync();

    }
}
