using System;
using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models
{
	public class AccountViewModel
	{
		public AccountViewModel()
		{
		}
		public class LoginViewModel
		{
			[Required(ErrorMessage ="Email is required")]
			[StringLength(30,ErrorMessage ="Email can be max 40 characters.")]
			public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
			[MinLength(6,ErrorMessage ="Minimum password length is 6 characters.")]
            [MaxLength(20, ErrorMessage = "Maximum password length is 20 characters.")]
            public string Password { get; set; }

			public bool RememberMe { get; set; }
		}
	}
}

