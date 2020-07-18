using System;
using System.Threading.Tasks;
using Domain;

namespace Api
{
    public class FastFakeDataProcessing : IJobProcessing
    {
        public async Task<int> Process(Job job)
        {
            var random = new Random();
            await Task.Delay(random.Next(40, 60));
            return random.Next(0, 10);
        }
    }
}