namespace Al_Noor.Application.Services
{
    public class ServicesYoung
        (IUnitOF_Work work, IMapper mapper) : IServicesYoung
    {
        public async Task<IEnumerable<YoungDto>> GetYoungDtosAllAsync()
        {
            var young = await work.GetRepoYoung.GetAllAsync(x=>x.Activity);
            return mapper.Map<IEnumerable<YoungDto>>(young);
        }
        public async Task<YoungDto> GetYoungDtoByIdAsync(int id)
        {
            var young = await work.GetRepoYoung.GetByIdAsync(id);
            if (young == null)
            {
                throw new KeyNotFoundException($"Young with id {id} not found.");
            }
            return mapper.Map<YoungDto>(young);
        }
        public async Task<YoungDto> CreateYoungDtoAsync(YoungDto youngDto)
        {
            if (youngDto == null)
            {
                throw new ArgumentNullException(nameof(youngDto), "YoungDto cannot be null.");
            }
            var young = mapper.Map<Young>(youngDto);
            var item = await work.GetRepoYoung.AddAsync(young);
            if (item == null)
            {
                throw new Exception("Failed to create YoungDto.");
            }
            await work.Complete();
            return mapper.Map<YoungDto>(item);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var young = await work.GetRepoYoung.GetByIdAsync(id);
            if (young == null) return false;
            work.GetRepoYoung.delete(young);
            await work.Complete();
            return true;

        }
    }
}
