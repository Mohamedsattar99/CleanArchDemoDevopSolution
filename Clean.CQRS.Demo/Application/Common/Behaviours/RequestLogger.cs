using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        
        public RequestLogger()
        {
           
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{typeof(TRequest).FullName} - Pre Processing", new { request });

            return Task.CompletedTask;
        }
    }
}