namespace Al_Noor.Application.IServices
{
    public interface IServicesYoung
    {
        Task<IEnumerable<YoungDto>> GetYoungDtosAllAsync();
        Task<YoungDto> GetYoungDtoByIdAsync(int id);
        Task<YoungDto> CreateYoungDtoAsync(YoungDto youngDto);
        Task<bool> DeleteAsync(int id);
    }
}
