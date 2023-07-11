using Microsoft.AspNetCore.Identity;

namespace LulukaBankIdentityProject.PresentationLayer.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return base.PasswordTooShort(length);
			//return new IdentityError()
			//{
			//	Code = "PasswordTooShort",
			//	Description = $"Wachtwoord moet uit minimaal {length} tekens bestaan"
			//};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Wachtwoord moet minimaal 1 hoofdletter bevatten"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Wachtwoord moet minimaal 1 kleine letter bevatten"
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Wachtwoord moet minsten 1 cijfer bevatten"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code= "PasswordRequiresNonAlphanumeric",
				Description= "Wachtwoord moet minsten 1 teken bevatten"
			};
		}
	}
}
