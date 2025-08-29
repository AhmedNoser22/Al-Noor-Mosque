namespace Al_Noor.Application.IServices
{
    public interface IServicesTeacher
    {
        Task<IEnumerable<TeacherDto>> GetTeacherDtosAllAsync();
        Task<TeacherDto> GetTeacherDtoByIdAsync(int id);
        Task<TeacherDto> CreateTeacherAsync(TeacherDto teacherDto);
    }
}
