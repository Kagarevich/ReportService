using Microsoft.AspNetCore.Mvc;
using ReportingService.Models;
using ReportingService.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        IWorkerWithReports rep;
        public ReportsController(IWorkerWithReports _rep)
        {
            rep = _rep;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> Get(int id)
        {
            Report report = await rep.Get(id);
            if (report == null)
                return NotFound();
            return new ObjectResult(report);
        }

        [HttpPost]
        public async Task<ActionResult<Report>> Post(Report report)
        {
            if (report == null)
            {
                return BadRequest();
            }
            await rep.Post(report);
            return Ok(report);
        }
    }
}
