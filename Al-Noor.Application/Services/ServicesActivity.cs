namespace Al_Noor.Application.Services
{
    public class ServicesActivity
        (IUnitOF_Work Work, IMapper mapper) : IServicesActivity
    {
        public async Task<IEnumerable<ActivityDto>> GetActivityDtos()
        {
            var activities = await Work.GetRepoActivity.GetAllAsync();
            return mapper.Map<IEnumerable<ActivityDto>>(activities);
        }
    }
}
