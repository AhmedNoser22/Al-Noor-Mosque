namespace Al_Noor.Application.IServices
{
    public interface IServicesChild
    {
        Task<ChildDto> GetChildDtoByIdAsync(int id);
        Task<IEnumerable<ChildDto>> GetChildDtoAllAsync();
        Task<ChildDto> CreateChildAsync(ChildDto childDto);
        Task<bool> DeleteAsync(int id);
    }

}
