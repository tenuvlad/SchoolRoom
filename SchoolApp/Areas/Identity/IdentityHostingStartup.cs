using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Areas.Identity.Pages.Account;

[assembly: HostingStartup(typeof(SchoolApp.Areas.Identity.IdentityHostingStartup))]
namespace SchoolApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
				services.AddSingleton<IEmailSender, EmailSender>();
			});
		}
	}
}