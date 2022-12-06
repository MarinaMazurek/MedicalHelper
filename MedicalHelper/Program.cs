using MediatR;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.Data.CQS.Commands;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Extantions;
using MedicalHelper.Repositories;
using Microsoft.EntityFrameworkCore;

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

            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<MedicalHelperDbContext>(
                optionsBuilder => optionsBuilder.UseSqlServer(connectionString));

            //builder.Services.AddDbContext<MedicalHelperDbContext>();


            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                       

            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserProfileService, UserProfileService>();
            builder.Services.AddScoped<IVisitService, VisitService>();
            builder.Services.AddScoped<IMedicineService, MedicineService>();
            builder.Services.AddScoped<IVaccinationService, VaccinationService>();


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            builder.Services.AddScoped<IVisitRepository, VisitRepository>();
            builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
            builder.Services.AddScoped<IVaccinationRepository, VaccinationRepository>();
            
            builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Configuration.AddJsonFile("secrets.json");

            builder.Services.AddMediatR(typeof(AddVisitCommand).Assembly);

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
            
            app.Seed();

            app.Run();
        }
    }
}