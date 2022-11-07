using FluentValidation;
using System;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).MinimumLength(4);
            RuleFor(x => x.Model.LastName).MinimumLength(4);
            RuleFor(x => x.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
