using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;

namespace Users.Application.Functions.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(20)
                .WithMessage("{PropertyName} must not exceed 20 characters");

            RuleFor(u => u.Surname)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(30)
                .WithMessage("{PropertyName} must not exceed 20 characters");

            RuleFor(u => u.EmailAddress)
                .NotEmpty()
                .WithMessage("Email address is required")
                .EmailAddress()
                .WithMessage("A valid email is required");

            RuleFor(u => u)
                .MustAsync(IsNameAndSurnameAlreadyExist)
                .WithMessage("User wit same Name and Surname already exist");


        }

        private async Task<bool> IsNameAndSurnameAlreadyExist(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        {
            return !(await _userRepository.IsNameAndSurnameAlreadyExist(createUserCommand.Name, createUserCommand.Surname));
        }
    }
}
