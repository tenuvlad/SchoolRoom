using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SchoolApp.Helper
{
	public static class IdentityConfiguration
	{
		public static IServiceCollection AddApplicationIdentity(
		this IServiceCollection services)
		{
			IdentityBuilder builder = services.AddIdentityCore<User>(options =>
			{
				//for development
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 4;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
			});

			builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);

			builder.AddEntityFrameworkStores<SchoolContext>();
			builder.AddRoleValidator<RoleValidator<Role>>();
			builder.AddRoleManager<RoleManager<Role>>();
			builder.AddSignInManager<SignInManager<User>>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
				options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
				options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
			})
			.AddCookie(IdentityConstants.ApplicationScheme, o =>
			{
				o.LoginPath = new PathString("/Account/Login");
				o.Events = new CookieAuthenticationEvents
				{
					OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
				};
			})
			.AddCookie(IdentityConstants.ExternalScheme, o =>
			{
				o.Cookie.Name = IdentityConstants.ExternalScheme;
				o.ExpireTimeSpan = TimeSpan.FromDays(1);
			})
			.AddCookie(IdentityConstants.TwoFactorRememberMeScheme, o =>
			{
				o.Cookie.Name = IdentityConstants.TwoFactorRememberMeScheme;
				o.Events = new CookieAuthenticationEvents
				{
					OnValidatePrincipal = SecurityStampValidator.ValidateAsync<ITwoFactorSecurityStampValidator>
				};
			})
			.AddCookie(IdentityConstants.TwoFactorUserIdScheme, o =>
			{
				o.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
				o.ExpireTimeSpan = TimeSpan.FromDays(1);
			});

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Identity/Account/Login";
				options.LogoutPath = $"/Identity/Account/Logout";
				options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
			});

			return services;
		}
	}
}
