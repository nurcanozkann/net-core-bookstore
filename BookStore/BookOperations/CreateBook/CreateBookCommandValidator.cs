using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(c => c.model.GenreId).GreaterThan(0);
            RuleFor(c => c.model.PageCount).GreaterThan(0);
            RuleFor(c => c.model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(c => c.model.Title).NotEmpty().MinimumLength(4);

        }
    }
}
