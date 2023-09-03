using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace Application.Common.Behaviours
{
    public class ResponseLogger<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {

        public ResponseLogger()
        {
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{typeof(TRequest).FullName} - Post Processing", new { request, response });

            return Task.CompletedTask;
        }
    }
}