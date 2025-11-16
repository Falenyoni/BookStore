using FluentValidation;

namespace BookStore.Api.Features.Books.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(100)
                .WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Author is required")
                .MaximumLength(50)
                .WithMessage("Author cannot exceed 50 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price  must be greater than 0.");

            RuleFor(x => x.PublishedOn)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Published date cannot be in the future");
        }
    }
}