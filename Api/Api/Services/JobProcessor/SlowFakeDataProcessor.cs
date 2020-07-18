using System;
using System.Threading.Tasks;
using Domain;

namespace Api
{
    public class SlowFakeDataProcessing : IJobProcessing
    {
        public async Task<int> Process(Job job)
        {
            var random = new Random();
            await Task.Delay(random.Next(400, 600));
            return random.Next(0, 10);
        }
    }
}