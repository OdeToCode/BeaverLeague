using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BeaverLeague.Web.Services
{
    public class BeaverMediator : IMediator
    {
        private readonly ILogger<BeaverMediator> _logger;
        private readonly IMediator _inner;

        public BeaverMediator(SingleInstanceFactory single, MultiInstanceFactory multi, ILogger<BeaverMediator> logger)
        {
            _logger = logger;
            _inner = new Mediator(single, multi);
        }

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            _logger.LogTrace("Send {@request}", request);
            return _inner.Send(request);            
        }

        public Task<TResponse> SendAsync<TResponse>(ICancellableAsyncRequest<TResponse> request, CancellationToken cancellationToken)
        {
            _logger.LogTrace("SendAsync {@request}", request);
            return _inner.SendAsync(request, cancellationToken);
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            _logger.LogTrace("Send async {@request", request);
            return _inner.SendAsync(request);
        }

        public void Publish(INotification notification)
        {
            _logger.LogTrace("Publish {@notification}", notification);
            _inner.Publish(notification);
        }

        public Task PublishAsync(IAsyncNotification notification)
        {
            _logger.LogTrace("PublishAsync {@notification}", notification);
            return _inner.PublishAsync(notification);
        }

        public Task PublishAsync(ICancellableAsyncNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace("PublishAsync {@notification}", notification);
            return _inner.PublishAsync(notification, cancellationToken);
        }
    }
}