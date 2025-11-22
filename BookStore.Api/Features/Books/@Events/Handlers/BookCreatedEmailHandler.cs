using MediatR;

namespace BookStore.Api.Features.Books._Events.Handlers
{
    public class BookCreatedEmailHandler : INotificationHandler<BookCreatedEvent>
    {
        private readonly ILogger<BookCreatedEmailHandler> _logger;

        public BookCreatedEmailHandler(ILogger<BookCreatedEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Simulate sending email
            _logger.LogInformation("Email sent: New Book '{Title}' added to Catalog.",
                notification.Title);

            return Task.CompletedTask;
        }
    }
}