using System.Linq;
using SimpleStore.Database;
using SimpleStore.Database.DAL;
using SimpleStore.Database.DAL.Enums;

namespace SimpleStore.Models.Misc.DbInitializers
{
    public class DefaultUserInitializer:IInitializer
    {

        /// <summary>
        /// Инициализация базы данных дефолтными  пользователями (админом и юзером)
        /// </summary>
        /// <param name="context"></param>
        public  void Initialize(StoreContext context)
        {
            var admin = CreateDefaultAdmin(context);
            var user = CreateDefaultUser(context);
            context.Users.AddRange(admin, user);
            context.SaveChanges();
        }

        /// <summary>
        /// Инициализация юзера с роль admin
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public void InitializeDefaultAdmin(StoreContext context)
        {
            context.Users.Add(CreateDefaultAdmin(context));
            context.SaveChanges();
        }

        /// <summary>
        /// Создания пользователя по умолчанию с ролью админ 
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        /// <returns>Пользователь с ролью admin</returns>
        private User CreateDefaultAdmin(StoreContext context)
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
        /// <returns>Пользователь с ролью user</returns>
        private User CreateDefaultUser(StoreContext context)
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
