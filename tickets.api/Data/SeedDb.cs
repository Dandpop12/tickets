using tickets.api.Helpers;
using tickets.shared.Enums;
using tickets.shared.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tickets.api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEmpresasAsync();
            await CheckClasificacionesAsync();

            await CheckRolesAsync();
            await CheckUserAsync(1422, "Dangiro", "Polanco", "Administrator", "dangiro_polanco@outlook.com", "829 533 5029", UserType.Super_User);

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Super_User.ToString());
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(int document, string firstName, string lastName, string userName, string email, string phone, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {

                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Estado = EstadosGenerales.Activo,
                    URL_Imagen = null,
                    Email = email,
                    UserName = userName,
                    PhoneNumber = phone,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }


        #region Data General

        private async Task CheckEmpresasAsync()
        {
            if (!_context.Generales_Empresas.Any())
            {
                _context.Generales_Empresas.Add(new Generales_Empresas
                {
                    Nombre = "DEMO - GENERAL",
                    NombreComercial = "DEMO - GENERAL",
                    RNC = "0000000000",
                    Telefono = "(000) 000-0000",
                    Direccion = "DIRECCIÓN DE PRUEBA",
                    Correo = "info@empresa.com",
                    URL_Imagen = string.Empty,
                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckClasificacionesAsync()
        {
            if (!_context.Clientes_Clasificaciones.Any())
            {
                _context.Clientes_Clasificaciones.Add(new Clientes_Clasificacion { Descripcion = "Verde", Color = "#30a671" });
                _context.Clientes_Clasificaciones.Add(new Clientes_Clasificacion { Descripcion = "Amarillo", Color = "#dca10d" });
                _context.Clientes_Clasificaciones.Add(new Clientes_Clasificacion { Descripcion = "Rojo", Color = "#ef4343" });
                _context.Clientes_Clasificaciones.Add(new Clientes_Clasificacion { Descripcion = "Otros", Color = "#811aa1" });
            }

            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
