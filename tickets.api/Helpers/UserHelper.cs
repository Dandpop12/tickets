using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tickets.api.Data;
using tickets.shared.DTOs;
using tickets.shared.Models;

namespace tickets.api.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users
               .ToListAsync();
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await _context.Users
               .FirstOrDefaultAsync(x => x.UserName == username);

            if (user != null)
            {
                var roles = _roleManager.Roles.ToList();
                var rolesView = new List<RolesDTO>();

                foreach (var item in roles)
                {
                    //var role = roles.Find(r => r.Id == item.Id);

                    var roleName = item.Name!;

                    var u = await _userManager.IsInRoleAsync(user!, roleName);
                    if (u)
                    {
                        var roleView = new RolesDTO
                        {
                            RoleID = item.Id,
                            Name = roleName,
                        };
                        rolesView.Add(roleView);
                    }
                }

                user!.Roles = rolesView;
            }
            
            return user!;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId.ToString());
            return user!;
        }

        public async Task<User> GetUserASPAsync(string email)
        {
            var user = await _context.Users
               .FirstOrDefaultAsync(x => x.Email == email);

            return user!;

        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }
    }
}

