using Domain;

namespace Api
{
    public class JobsStateResponse
    {
        public JobState[] States { get; set; }

        public class JobState
        {
            public string Id { get; set; }
            public Domain.JobState State { get; set; }
        }
    }
}