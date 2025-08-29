namespace Al_Noor_Mosque.Controllers
{
    public class YoungsController : Controller
    {
        private readonly IServicesYoung _services;
        private readonly FileHelper _fileHelper;
        private readonly SelectListHelper _selectListHelper;
        private readonly IMapper _mapper;
        public YoungsController(IServicesYoung services, FileHelper fileHelper, SelectListHelper selectListHelper, IMapper mapper)
        {
            _services = services;
            _fileHelper = fileHelper;
            _selectListHelper = selectListHelper;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var youngs = await _services.GetYoungDtosAllAsync();
            var youngDisplayVMs = _mapper.Map<IEnumerable<YoungDisplayVM>>(youngs);
            return View(youngDisplayVMs);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new YoungVM
            {
                Activities = await _selectListHelper.GetActivitiesSelectListAsync()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateYoung(YoungVM young)
        {
            if (!ModelState.IsValid)
            {
                young.Activities = await _selectListHelper.GetActivitiesSelectListAsync();
                return View(nameof(Create), young);
            }
            var imagepath = await _fileHelper.SaveImages(young);
            var youngDto = _mapper.Map<YoungDto>(young);
            youngDto.image = imagepath;
            var createdYoung = await _services.CreateYoungDtoAsync(youngDto);
            young.Activities = await _selectListHelper.GetActivitiesSelectListAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id,string imagepPath)
        {
            _fileHelper.DeleteImage(imagepPath);

            var result = await _services.DeleteAsync(id);
            if (!result)
                return BadRequest("فشل الحذف");
            return RedirectToAction(nameof(Index));
        }


    }
}
