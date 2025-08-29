namespace Al_Noor.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Teacher
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.Name));
            CreateMap<TeacherDto, Teacher>()
                .ForMember(dest => dest.Activity, opt => opt.Ignore()); // مهم عشان ما يحاولش يعمل Activity جديدة 
            #endregion
            #region Children
            CreateMap<Child, ChildDto>()      
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.Name));
            CreateMap<ChildDto, Child>()
                .ForMember(dest => dest.Activity, opt => opt.Ignore()); // مهم عشان ما يحاولش يعمل Activity جديدة
            #endregion
            #region Young
            CreateMap<Young, YoungDto>()
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.Name));
            CreateMap<YoungDto, Young>()
                .ForMember(dest => dest.Activity, opt => opt.Ignore()); // مهم عشان ما يحاولش يعمل Activity جديدة
            #endregion
            #region Activity
            CreateMap<Activity, ActivityDto>();
            #endregion
            #region Award
            CreateMap<Award, AwardDto>()
                    .ForMember(x => x.Date, x => x.Ignore());
            #endregion
            #region Worker
            CreateMap<Worker, WorkerDto>()
                .ReverseMap();
            #endregion
            #region UserRegister
            CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));
            #endregion
            #region login
            CreateMap<LoginDto, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.UserName));
            #endregion
            #region Role
            CreateMap<RoleDto, IdentityRole>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<AppUser, ManagerDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            #endregion
        }
    }
}
