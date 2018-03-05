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

        public async Task<T> Send<T>(IRequest<T> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogTrace("SendAsync {@request}", request);

            var response = await _inner.Send(request, cancellationToken);
            LogResponseIfError(response);
            return response;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
        {
            _logger.LogTrace("PublishAsync {@notification}", notification);
            return _inner.Publish(notification, cancellationToken);
        }

        public Task Send(IRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogTrace("SendAsync {@request}", request);
            return _inner.Send(request, cancellationToken);
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