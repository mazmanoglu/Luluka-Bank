using FluentValidation;
using LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LulukaBankIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
	public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name cannot be empty");
			RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name cannot be empty");
			RuleFor(u => u.Username).NotEmpty().WithMessage("Username cannot be empty");
			RuleFor(u => u.Email).NotEmpty().WithMessage("Email cannot be empty");
			RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be empty");
			RuleFor(u => u.ConfirmPassword).NotEmpty().WithMessage("Confirm password cannot be empty");
			RuleFor(u => u.FirstName).MaximumLength(30).WithMessage("First name cannot be longer than 30 characters");
			RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("First name cannot be shorter than 2 characters");
			RuleFor(u => u.Email).EmailAddress().WithMessage("Please write an email address");
			RuleFor(u=>u.ConfirmPassword).Equal(y => y.Password).WithMessage("Confirm Password does not match with Password");
		}
	}
}
