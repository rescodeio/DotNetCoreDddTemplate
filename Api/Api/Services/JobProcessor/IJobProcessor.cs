using System.Threading.Tasks;
using Domain;

namespace Api
{
    public interface IJobProcessing
    {
        public Task<int> Process(Job job);
    }
}