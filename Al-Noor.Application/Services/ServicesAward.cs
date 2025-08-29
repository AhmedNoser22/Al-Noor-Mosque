namespace Al_Noor.Application.Services
{
    public class ServicesAward
        (IUnitOF_Work work , IMapper mapper): IServicesAward
    {

        public async Task<IEnumerable<AwardDto>> GetAllAwardDtosAsync()
        {
            var award =await work.GetRepoAward.GetAllAsync();
            return mapper.Map<IEnumerable<AwardDto>>(award);
        }


        

        
    }
}
