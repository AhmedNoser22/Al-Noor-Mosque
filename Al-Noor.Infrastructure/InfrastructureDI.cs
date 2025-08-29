namespace Al_Noor.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            services.AddScoped<IUnitOF_Work, UnitOF_Work>();
            return services;
        }

    }
}
