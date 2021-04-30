using Microsoft.EntityFrameworkCore;
using ReportingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Server
{
    public class Reports : IWorkerWithReports
    {
        ApplicationContext db;
        public Reports(ApplicationContext context)
        {
            db = context;
        }
        public async Task<Report> Get(int id)
        {
            return await db.Reports.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task Post(Report report)
        {
            db.Reports.Add(report);
            await db.SaveChangesAsync();
        }
    }
}
