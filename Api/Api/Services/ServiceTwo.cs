namespace Api.Services
{
    public class ServiceTwo : ISomeService
    {
        public string GetInfo()
        {
            return GetType().Name;
        }
    }
}