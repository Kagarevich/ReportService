using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int ProviderId { get; set; }
        public int Sum { get; set; }
        [Required]
        public int ReportId { get; set; }

        public Report Report { get; set; }
        public Provider Provider { get; set; }
    }
}
