using MediatR;

namespace BookStore.Api.Features.Books._Events.Handlers
{
    public class BookCreatedLoggingHandler : INotificationHandler<BookCreatedEvent>
    {
        private readonly ILogger<BookCreatedLoggingHandler> _logger;

        public BookCreatedLoggingHandler(ILogger<BookCreatedLoggingHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Domain Event: BookCreated -> {Title} by " +
                "{Author}",
                notification.Title, notification.Author);

            return Task.CompletedTask;
        }
    }
}