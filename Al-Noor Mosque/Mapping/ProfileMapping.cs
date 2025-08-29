namespace Al_Noor_Mosque.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            #region Teacher
            CreateMap<TeacherVM, TeacherDto>()
                .ForMember(dest => dest.image, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityName, opt => opt.Ignore());
            CreateMap<TeacherDto, TeacherDisplayVM>();
            #endregion
            #region  Children

            CreateMap<ChildVM, ChildDto>()
                .ForMember(dest => dest.ActivityName, opt => opt.Ignore());
            CreateMap<ChildDto, ChildDisplayVM>();
            #endregion;
            #region Young
            CreateMap<YoungVM, YoungDto>()
                .ForMember(dest => dest.ActivityName, opt => opt.Ignore())
                .ForMember(dest => dest.image, opt => opt.Ignore());
            CreateMap<YoungDto, YoungDisplayVM>();
            #endregion;
            #region Activity
            CreateMap<ActivityDto, ActivityVM>();
            #endregion
            #region Award
            CreateMap<AwardDto, AwardVM>();
            #endregion
            #region Worker
            CreateMap<WorkerDto, WorkerDisplayVM>();
            CreateMap<WorkerVM, WorkerDto>()
                .ForMember(dest => dest.image, opt => opt.Ignore());

            #endregion
            #region UserRegister
            CreateMap<UserRegister, RegisterDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));
            #endregion
            #region login
            CreateMap<UserLogin,LoginDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.UserName));
            #endregion
            #region role
            CreateMap<RoleDto, GetRoleVM>();
            CreateMap<AddRoleVM, RoleDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ManagerDto,ManagerVM>()
                .ReverseMap();
            #endregion

        }
    }
}
