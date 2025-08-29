namespace Al_Noor.Application.Services
{
    public class ServicesChild : IServicesChild
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper mapper;
        public ServicesChild(IMapper mapper, IUnitOF_Work work)
        {
            this.mapper = mapper;
            this.work = work;
        }

        public async Task<IEnumerable<ChildDto>> GetChildDtoAllAsync()
        {
            var child = await work.GetRepoChild.GetAllAsync(x => x.Activity);
            return mapper.Map<IEnumerable<ChildDto>>(child);
        }
        public async Task<ChildDto> GetChildDtoByIdAsync(int id)
        {
            var child = await work.GetRepoChild.GetByIdAsync(id);
            if (child == null)
            {
                throw new KeyNotFoundException($"Child with ID {id} not found.");
            }
            return mapper.Map<ChildDto>(child);
        }
        public async Task<ChildDto> CreateChildAsync(ChildDto childDto)
        {
            if (childDto == null)
            {
                throw new ArgumentNullException(nameof(childDto), "ChildDto cannot be null.");
            }
            var child = mapper.Map<Child>(childDto);
            var item = await work.GetRepoChild.AddAsync(child);
            if (item == null)
            {
                throw new Exception("Failed to create child.");
            }
            await work.Complete();
            return mapper.Map<ChildDto>(item);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var child = await work.GetRepoChild.GetByIdAsync(id);
            if (child == null)return false;
            work.GetRepoChild.delete(child);
            await work.Complete();
            return true;
        }
    }
}
