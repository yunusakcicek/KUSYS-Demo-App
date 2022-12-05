using System;
using System.Security.Claims;
using KUSYS_Demo.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using NETCore.Encrypt.Extensions;
using static KUSYS_Demo.Models.AccountViewModel;

namespace KUSYS_Demo.Services
{
	public class AccountService : BaseService
	{
        private readonly CoreServices _coreServices;
        public AccountService(DatabaseContext databaseContext, IConfiguration configuration) : base(databaseContext, configuration)
		{
            _coreServices = new CoreServices(databaseContext, configuration);
        }

		public bool ControlLogin(LoginViewModel loginViewModel, HttpContext httpContext)
		{
			try
			{
				//Checking if mail exist in database
				var userData_ = _databaseContext.UserData.Where(x => x.Email.Equals(loginViewModel.Email)).FirstOrDefault();

                if (userData_ != null)
				{
					//Checking if user is locked
					if (userData_.Locked)
					{
						return false;
					}
					else
					{
                        //checking if password matches with encrypted password
                        string encryptedPassword_ = _coreServices.EncryptPassword(loginViewModel.Password);
                        if (!string.IsNullOrEmpty(encryptedPassword_))
                        {
                            if (userData_.Password.Equals(encryptedPassword_))
                            {
								List<Claim> claims = new List<Claim>();
								claims.Add(new Claim("UserId", userData_.UserId.ToString()));
                                claims.Add(new Claim("StudentId", userData_.StudentId != Guid.Empty ? userData_.StudentId.ToString() : ""));
                                claims.Add(new Claim("FullName", userData_.FirstName.ToString()+" "+userData_.LastName.ToString()));
                                claims.Add(new Claim("Email", userData_.Email.ToString()));
                                claims.Add(new Claim("Roles", userData_.UserRole.ToString()));

								ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

								ClaimsPrincipal principal = new ClaimsPrincipal(identity);
								httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                                return true;
                            }
                        }
                    }
				}
				return false;
			}
			catch (Exception ex)
			{
				//Error log here.
				return false;
			}
		}
	}
}

