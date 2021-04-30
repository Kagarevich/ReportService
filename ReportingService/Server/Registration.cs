using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportingService.Models;
using ReportingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReportingService.Server
{
    public class Registration : IWorkerWithUser
    {
        ApplicationContext db;
        public Registration(ApplicationContext context)
        {
            db = context;
        }
        public async Task<int> Post(RegisterModel model)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.Login == model.Login);
            if (user == null)
            {
                user = new User { Login = model.Login, Email = model.Email, Password = model.Password };
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
            return user.Id;
        }
        public async Task<int> Login(LoginModel model)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
            if (user != null) return user.Id;
            else return 0;
        }
    }
}
