﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.AppUserDTOs
{
   public class AppUserEditDTO
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string District { get; set; }
      public string City { get; set; }
      public string ImageURL { get; set; }
      public string Email { get; set; }
      public string PhoneNumber { get; set; }
      public string Password { get; set; }
      public string ConfirmPassword { get; set; }
   }
}
