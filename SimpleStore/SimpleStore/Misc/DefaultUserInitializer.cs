using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using SimpleStore.Database;
using SimpleStore.Database.DAL;
using SimpleStore.Database.DAL.Enums;

namespace SimpleStore.Misc
{
    public static class DefaultUserInitializer
    {

        /// <summary>
        /// Инициализация базы данных дефолтными  пользователями (админом и юзером)
        /// </summary>
        /// <param name="context"></param>
        public static  void Initialize(StoreContext context)
        {
            var admin = CreateDefaultAdmin(context);
            var user = CreateDefaultUser(context);
            context.Users.AddRange(admin, user);
            context.SaveChanges();
        }

        /// <summary>
        /// Создания пользователя по умолчанию с ролью админ 
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        /// <returns></returns>
        private static User CreateDefaultAdmin(StoreContext context)
        {
            var adminRole = context.Roles.FirstOrDefault(r => r.Role == Role.Admin);

            var adminProfile = new UserProfile()
            {
                Name = "Admin",
                Surname = "Adminovich",
                PhoneNumber = "+7 800 555 35 35",
                Street = "Main Street",
                City = "Main City",
            };
            var admin = new User()
            {
                Email = "admin@admin.ru",
                NickName = "admin",
                Password = PasswordExtension.GetHashFromSalPassword("admin", "admin"),
                Role = adminRole,
                RoleId = adminRole.Id,
            };
            admin.Profile = adminProfile;
            return admin;
        }

        /// <summary>
        /// Создания пользователя по умолчанию с ролью простой пользователь 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static User CreateDefaultUser(StoreContext context)
        {
            var userRole = context.Roles.FirstOrDefault(r => r.Role == Role.User);

            var userProfile = new UserProfile()
            {
                Name = "User",
                Surname = "Userovich",
                PhoneNumber = "+7 800 555 35 35",
                Street = "Main Street",
                City = "Main City",
            };
            var user = new User()
            {
                Email = "user@user.ru",
                NickName = "user",
                Password = PasswordExtension.GetHashFromSalPassword("user", "user"),
                Role = userRole,
                RoleId = userRole.Id,
            };
            user.Profile = userProfile;
            return user;
        }
    }
}
