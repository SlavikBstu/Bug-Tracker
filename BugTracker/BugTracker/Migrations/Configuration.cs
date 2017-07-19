namespace BugTracker.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var administrator_role = new IdentityRole { Name = "admin" };
            var moderator_role = new IdentityRole { Name = "moderator" };
            var worker_role = new IdentityRole { Name = "worker" };
            var user_role = new IdentityRole { Name = "user" };



            // ��������� ���� � ��
            roleManager.Create(administrator_role);
            roleManager.Create(moderator_role);
            roleManager.Create(worker_role);
            roleManager.Create(user_role);

            // ������� �������������
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru"};
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded)
            {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, administrator_role.Name);
            }

            base.Seed(context);
        }
    }
}
