using System.Threading.Tasks;
using Api.Controllers;

namespace Api
{
    public interface IGetJobReport
    {
        Task<JobReportResponse> Get(string id);
    }
}