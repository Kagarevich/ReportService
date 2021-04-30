using Microsoft.AspNetCore.Mvc;
using ReportingService.Models;
using ReportingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Server
{
    public interface IWorkerWithUser
    {
        public Task<int> Post(RegisterModel model);
        public Task<int> Login(LoginModel model);
    }
}
