namespace Al_Noor_Mosque.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IServicesTeacher _teacherService;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        private readonly SelectListHelper _selectListHelper;

        public TeachersController(FileHelper fileHelper, IMapper mapper, IServicesTeacher teacherService, SelectListHelper selectListHelper)
        {
            _fileHelper = fileHelper;
            _mapper = mapper;
            _teacherService = teacherService;
            _selectListHelper = selectListHelper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TeacherDto> teachers =await _teacherService.GetTeacherDtosAllAsync();
            var item =  _mapper.Map<IEnumerable<TeacherDisplayVM>>(teachers);
            return View(item);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teacher = new TeacherVM
            {
                Activities = await _selectListHelper.GetActivitiesSelectListAsync()
            };
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherVM teacher)
        {
            if (!ModelState.IsValid)
            {
                teacher.Activities = await _selectListHelper.GetActivitiesSelectListAsync();
               

                return View(nameof(Create),teacher);
            }

            var imagePath = await _fileHelper.SaveImages(teacher);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            teacherDto.image = imagePath;
            await _teacherService.CreateTeacherAsync(teacherDto);
            teacher.Activities = await _selectListHelper.GetActivitiesSelectListAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
