namespace Al_Noor.Application.Services
{
    public class ServicesTeacher
        (IUnitOF_Work work,IMapper mapper): IServicesTeacher
    {
        public async Task<IEnumerable<TeacherDto>> GetTeacherDtosAllAsync()
        {
            IEnumerable<Teacher> teachers =await work.GetRepoTeacher.GetAllAsync(x=>x.Activity);
            return mapper.Map<IEnumerable<TeacherDto>>(teachers);
        }
        public async Task<TeacherDto> GetTeacherDtoByIdAsync(int id)
        {
            var teacher =await work.GetRepoTeacher.GetByIdAsync(id);
            if (teacher == null)
            {
                throw new KeyNotFoundException($"Teacher with ID {id} not found.");
            }
            return mapper.Map<TeacherDto>(teacher);
        }
        public async Task<TeacherDto> CreateTeacherAsync(TeacherDto teacherDto)
        {
            if(teacherDto==null)
            {
                throw new ArgumentNullException(nameof(teacherDto), "TeacherDto cannot be null.");
            }
           Teacher teacher = mapper.Map<Teacher>(teacherDto);
           Teacher item = await work.GetRepoTeacher.AddAsync(teacher);
            if (item == null)
            {
                throw new Exception("Failed to create teacher.");
            }
            await work.Complete();
            return mapper.Map<TeacherDto>(item);
        }
    }
}
