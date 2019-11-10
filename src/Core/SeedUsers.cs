using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;


namespace Core
{
    public static class SeedUsers
    {
        private const string Admin = "Admin";
        private const string Employee = "Employee";
        public static async Task Seed(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync(Admin);
            if (!adminRoleExists)
            {
                var role = new IdentityRole { Name = Admin };
                await roleManager.CreateAsync(role);

                //Here we create a Admin super user who will maintain the website
                var user = new ApplicationUser
                {
                    Name = "Admin",
                    UserName = "admin",
                    Email = "admin@xpchain.com",
                    EmailConfirmed = true
                };

                const string userPwd = "Pwd+123";

                var chkUser =
                    await userManager.CreateAsync(
                        user,
                        userPwd);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(
                        user,
                        Admin);
                }
            }

            var employeeRoleExists =
                await roleManager.RoleExistsAsync(Employee);
            if (!employeeRoleExists)
            {
                var role = new IdentityRole {Name = Employee};
                await roleManager.CreateAsync(role);
            }
        }
    }
}
