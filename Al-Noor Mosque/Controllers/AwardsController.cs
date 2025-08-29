namespace Al_Noor_Mosque.Controllers
{
    public class AwardsController(IServicesAward services,IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var awards =await services.GetAllAwardDtosAsync();
            var awardVMs = mapper.Map<IEnumerable<AwardVM>>(awards);
            return View(awardVMs);
        }
    }
}
