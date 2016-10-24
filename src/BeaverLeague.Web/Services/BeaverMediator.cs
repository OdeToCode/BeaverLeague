using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BeaverLeague.Web.Services
{
    public class BeaverMediator : IMediator
    {
        private readonly IMediator _inner;

        public BeaverMediator(SingleInstanceFactory single, MultiInstanceFactory multi)
        {
            _inner = new Mediator(single, multi);
        }

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            return _inner.Send(request);
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            return _inner.SendAsync(request);
        }

        public void Publish(INotification notification)
        {
            _inner.Publish(notification);
        }

        public Task PublishAsync(IAsyncNotification notification)
        {
            return _inner.PublishAsync(notification);
        }

        public Task PublishAsync(ICancellableAsyncNotification notification, CancellationToken cancellationToken)
        {
            return _inner.PublishAsync(notification, cancellationToken);
        }

        public Task<TResponse> SendAsync<TResponse>(ICancellableAsyncRequest<TResponse> request, CancellationToken cancellationToken)
        {
            return _inner.SendAsync(request, cancellationToken);
        }
    }
}
