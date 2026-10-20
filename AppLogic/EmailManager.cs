using Azure;
using Azure.Communication.Email;

namespace AppLogic
{
    public interface IEmailManager
    {
        string SendEmail(string emailAddress);//DTO de email
    }
    public class EmailManager : IEmailManager
    {
        public string SendEmail(string emailAddress)
        {
            string connectionString = "su connection string";
            var emailClient = new EmailClient(connectionString);


            var emailMessage = new EmailMessage(
                senderAddress: "DoNotReply@50542089-1458-4351-8801-e68e03bc16d5.azurecomm.net",
                content: new EmailContent("correo electronico de prueba")
                {
                    Html = @"
		                    <html>
			                    <body>
				                    <h1 style='color: red'>
					                    Hola Mundo por correo. :)
				                    </h1>
			                    </body>
		                    </html>"
                },
                recipients: new EmailRecipients(new List<EmailAddress>
                {
                     new EmailAddress(emailAddress)
                }));


            EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);

            return emailSendOperation.Value.Status.ToString();
        }
    }
}