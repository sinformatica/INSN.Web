using INSN.Web.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess
{
    public class UserDataSeeder
    {
        public static async Task Seed(IServiceProvider service)
        {
            // Repositorio de usuarios
            var userManager = service.GetRequiredService<UserManager<INSNIdentityUser>>();

            // Repositorio de roles
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            // Crear roles
            var AdminSistemasRole = new IdentityRole(Constantes.RolAdminSistemas);

            if (!await roleManager.RoleExistsAsync(Constantes.RolAdminSistemas))
                await roleManager.CreateAsync(AdminSistemasRole);

            // Creamos el usuario Admin
            var adminUser = new INSNIdentityUser
            {
                Nombres = "Administrador",
                ApellidoPaterno = "Sistemas",
                ApellidoMaterno = "INSN",
                servicio = "9999",
                UserName = "AdminSistemas",
                Email = "adminsistemas@gmail.com",
                PhoneNumber = "+1 999 999 999",
                TipoDocumentoIdentidadId = 1,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin1234");

            if (result.Succeeded)
            {
                // Esto me asegura que el usuario se creó correctamente
                adminUser = await userManager.FindByEmailAsync(adminUser.Email);
                if (adminUser is not null)
                    await userManager.AddToRoleAsync(adminUser, Constantes.RolAdminSistemas);
            }
        }
    }
}
