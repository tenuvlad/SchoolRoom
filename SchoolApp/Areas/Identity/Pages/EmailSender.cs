using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace SchoolApp.Areas.Identity.Pages.Account
{
	public class EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string message)
		{
			return Task.CompletedTask;
		}

		Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
		{
			throw new System.NotImplementedException();
		}
	}
}
