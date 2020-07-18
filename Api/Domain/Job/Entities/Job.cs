using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public JobState State { get; set; }
        public JobType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<DataPoint> DataPoints { get; set; }
        public List<Log> Logs { get; set; }
    }
}