namespace Al_Noor_Mosque.Controllers
{
    public class ActivitiesController(IServicesActivity services,IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var activities =await services.GetActivityDtos();
            var activityDtos = mapper.Map<IEnumerable<ActivityVM>>(activities);
            return View(activityDtos);

        }
    }
}
