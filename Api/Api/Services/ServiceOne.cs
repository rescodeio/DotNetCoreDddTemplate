namespace Api.Services
{
    public class ServiceOne : ISomeService
    {
        public string GetInfo()
        {
            return GetType().Name;
        }
    }
}