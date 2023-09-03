using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Extranet.Hotels.PropertiesManagement.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;

        public RequestPerformanceBehaviour()
        {
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            long maxElapsedTimeOfRunningRequest = 300; 
            if (_timer.ElapsedMilliseconds > maxElapsedTimeOfRunningRequest)
            {
                Console.WriteLine($"{typeof(TRequest).FullName} - Long Running", new
                {
                    ElapsedMilliseconds = $"{_timer.ElapsedMilliseconds} milliseconds",
                    Request = request
                });
            }

            return response;
        }
    }
}