using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
            RuleFor(c => c.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
