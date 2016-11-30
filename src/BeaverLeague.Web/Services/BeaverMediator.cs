using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Web.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;

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

            var response = _inner.Send(request);
            LogResponseIfError(response);
            return response;
        }

        public async Task<TResponse> SendAsync<TResponse>(ICancellableAsyncRequest<TResponse> request, CancellationToken cancellationToken)
        {
            _logger.LogTrace("SendAsync {@request}", request);

            var response =  await _inner.SendAsync(request, cancellationToken);
            LogResponseIfError(response);
            return response;
        }

        public async Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            _logger.LogTrace("Send async {@request", request);

            var response = await _inner.SendAsync(request);
            LogResponseIfError(response);
            return response;
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

        private void LogResponseIfError(object response)
        {
            var commandResult = response as CommandResult;
            if (commandResult != null && !commandResult.Success)
            {
                _logger.LogWarning(
                    $"Error in {response.GetType()}: {commandResult.Errors.Aggregate(new StringBuilder(), (sb, e) => sb.AppendLine(e), sb => sb.ToString())}");
            }
        }
    }
}