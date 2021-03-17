using Core.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();

            //  RuleFor(u => u.Status).NotEmpty();
            //  RuleFor(u => u.PasswordSalt).NotEmpty();
            //  RuleFor(u => u.PasswordHash).NotEmpty();
            ////  RuleFor(u => u.FirstName).MinimumLength(5);
            /// RuleFor(u => u.Id).NotEmpty();




        }
    }
}
