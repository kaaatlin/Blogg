using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BLog.BLL.Services.IServices;
using BLog.BLL.ViewModels.Users;
using BLog.DAL.Models;

namespace BLog.BLL.Services
{
    public class HomeService : IHomeService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public IMapper _mapper;

        public HomeService(RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task GenerateData()
        {
            var testUser = new UserRegisterViewModel { UserName = "Admin", Email = "admin@mail.ru", Password = "12345", FirstName = "Iiii", LastName = "Iiiiii" };
            var testUser2 = new UserRegisterViewModel { UserName = "Moder", Email = "moderator@mail.ru", Password = "12345", FirstName = "Ssssss", LastName = "Ssssss" };
            var testUser3 = new UserRegisterViewModel { UserName = "User", Email = "user@mail.ru", Password = "12345", FirstName = "Pppp", LastName = "Pppppp" };

            var user = _mapper.Map<User>(testUser);
            var user2 = _mapper.Map<User>(testUser2);
            var user3 = _mapper.Map<User>(testUser3);

            var userRole = new Role() { Name = "Пользователь", Description = "Пользователь" };
            var moderRole = new Role() { Name = "Модератор", Description = "Модератор" };
            var adminRole = new Role() { Name = "Администратор", Description = "Администратор" };

            await _userManager.CreateAsync(user, testUser.Password);
            await _userManager.CreateAsync(user2, testUser2.Password);
            await _userManager.CreateAsync(user3, testUser3.Password);

            await _roleManager.CreateAsync(userRole);
            await _roleManager.CreateAsync(moderRole);
            await _roleManager.CreateAsync(adminRole);

            await _userManager.AddToRoleAsync(user, adminRole.Name);
            await _userManager.AddToRoleAsync(user2, moderRole.Name);
            await _userManager.AddToRoleAsync(user3, userRole.Name);
        }
    }
}
