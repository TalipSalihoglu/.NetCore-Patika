using System;

namespace WebApi.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            //TODO
            Console.WriteLine("[DbLogger] - "+message);
        }
    }
}