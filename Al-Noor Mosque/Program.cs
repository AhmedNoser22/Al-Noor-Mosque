using Al_Noor_Mosque.Mapping;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<Al_Noor.Infrastructure.Data.AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddInfrastructure()
            .AddBusiness();
        builder.Services.AddScoped<FileHelper>()
            .AddScoped<SelectListHelper>();
        builder.Services.AddAutoMapper(typeof(ProfileMapping));
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error.html");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=login}/{id?}");

        app.Run();
    }
}
