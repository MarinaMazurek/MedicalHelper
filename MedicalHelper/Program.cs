using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.DataBase;
using MedicalHelper.Repositories;

namespace MedicalHelper
{
    public class Program
    {
        public const string AuthName = "MedicalHelperCoockie";
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(AuthName)
                .AddCookie(AuthName, config =>
                {
                    config.LoginPath = "/User/Email";
                    config.AccessDeniedPath = "/User/Denied";
                    config.Cookie.Name = "Smile";
                });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<MedicalHelperDbContext>();


            builder.Services.AddScoped<UserRepository, UserRepository>();
            builder.Services.AddScoped<UserService, UserService>();

            builder.Services.AddScoped<UserProfileRepository, UserProfileRepository>();
            builder.Services.AddScoped<UserProfileService, UserProfileService>();

            builder.Services.AddScoped<VisitRepository, VisitRepository>();
            builder.Services.AddScoped<VisitService, VisitService>();

            builder.Services.AddScoped<MedicineRepository, MedicineRepository>();
            builder.Services.AddScoped<MedicineService, MedicineService>();

            builder.Services.AddScoped<VaccinationRepository, VaccinationRepository>();


            builder.Services.AddHttpContextAccessor();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}