namespace Al_Noor.Application
{
    public static class BusinessDI
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IServicesAward, ServicesAward>();
            services.AddScoped<IServicesActivity, ServicesActivity>();
            services.AddScoped<IServicesChild, ServicesChild>();
            services.AddScoped<IServicesWorker, ServicesWorker>();
            services.AddScoped<IServicesYoung, ServicesYoung>();
            services.AddScoped<IServicesTeacher, ServicesTeacher>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddIdentity<AppUser, IdentityRole>
                (
                option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequiredLength = 6;
                    option.Password.RequireLowercase = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                    option.User.RequireUniqueEmail = true;
                }
                )
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
