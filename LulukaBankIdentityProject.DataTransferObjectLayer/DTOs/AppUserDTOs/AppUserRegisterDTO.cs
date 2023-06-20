using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.AppUserDTOs
{
	public class AppUserRegisterDTO
	{
		/*
		[Required(ErrorMessage ="Name is required!")]
		[Display(Name ="Name: ")]
		[MaxLength(30,ErrorMessage ="You could enter maximum 30 characters!")]
		*/
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }

	}
}
