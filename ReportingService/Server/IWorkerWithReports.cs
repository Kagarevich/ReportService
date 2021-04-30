using ReportingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Server
{
    public interface IWorkerWithReports
    {
        public Task<Report> Get(int id);
        public Task Post(Report report);
    }
}
