namespace Al_Noor_Mosque.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly IServicesChild _services;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        private readonly SelectListHelper _selectListHelper;

        public ChildrenController(FileHelper fileHelper, IMapper mapper, SelectListHelper selectListHelper, IServicesChild services)
        {
            _fileHelper = fileHelper;
            _mapper = mapper;
            _selectListHelper = selectListHelper;
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var children =await _services.GetChildDtoAllAsync();
            var childrenVM = _mapper.Map<IEnumerable<ChildDisplayVM>>(children);
            return View(childrenVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var child = new ChildVM
            {
                Activities = await _selectListHelper.GetActivitiesSelectListAsync()
            };
            return View(child);
        }
        [HttpPost]
        public async Task<IActionResult> CreateChild(ChildVM child)
        {
            if (!ModelState.IsValid)
            {
                child.Activities = await _selectListHelper.GetActivitiesSelectListAsync();
                return View(child);
            }
            var childDto = _mapper.Map<ChildDto>(child);
            var item = await _services.CreateChildAsync(childDto);
            child.Activities = await _selectListHelper.GetActivitiesSelectListAsync();
            return RedirectToAction(nameof(Index),child);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // حذف الصورة لو فيه صورة محفوظة
           // _fileHelper.DeleteImage(imagePath);
            var result = await _services.DeleteAsync(id);
            if (!result)
                return BadRequest("فشل الحذف");

            return RedirectToAction(nameof(Index));
        }


    }
}
