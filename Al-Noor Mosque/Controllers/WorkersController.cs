namespace Al_Noor_Mosque.Controllers
{
    public class WorkersController(IServicesWorker services,IMapper mapper,FileHelper file) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var workers =await services.GetWorkerDtosAllAsync();
            var workerDtos = mapper.Map<IEnumerable<WorkerDisplayVM>>(workers);
            return View(workerDtos);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorker(WorkerVM worker)
        {
            if (!ModelState.IsValid)
            {
                return View(worker);
            }
            var image = await file.SaveImages(worker);
            var workerDto = mapper.Map<WorkerDto>(worker);
            workerDto.image = image;
            var createdWorker = await services.CreateWorkerDtoAsync(workerDto);
            return RedirectToAction(nameof(Index));


        }
    }
}
