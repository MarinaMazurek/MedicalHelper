using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;

namespace MedicalHelper.Extantions
{
    public static class SeedExtantion
    {                
        public static IHost Seed(this IHost host)
        {
            using (var service = host.Services.CreateScope())
            {
                InitUsers(service.ServiceProvider);
                InitRole(service.ServiceProvider);
            }
            return host;
        }

        private static void InitRole(IServiceProvider service)
        {
            var roleRepository = service.GetService<IRepository<Role>>();

            if (!roleRepository.FindBy(x => x.Name == "Admin").Any())
            {
                var role = new Role()
                {
                    Name = "Admin"                    
                };
                roleRepository.AddAsync(role);
            }
        }

        private static void InitUsers(IServiceProvider service)
        {
            var userRepository = service.GetService<IUserRepository>();
            var roleRepository = service.GetService<IRepository<Role>>();

            var role = roleRepository.FindBy(x => x.Name == "Admin").FirstOrDefault();

            if (!userRepository.FindBy(x => x.Role.Name == "Admin").Any())
            {
                var admin = new User()
                {
                    Email = "admin@mail.com",
                    PasswordHash = "admin",
                    Role = role                    
                };

                userRepository.AddAsync(admin);
            }
                       

            //var userDefaults = new List<User>()
            //{
            //    new User()
            //    {
            //        Login = "tom",
            //        Password = "123",
            //        Role = Role.User,
            //        Language = Language.English,
            //    },
            //    new User()
            //    {
            //        Login = "nik",
            //        Password = "123",
            //        Role = Role.User,
            //        Language = Language.Polish,
            //    },
            //};

        }        
    }
}
