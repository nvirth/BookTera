using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CommonPortable.Enums;
using CommonPortable.Exceptions;

namespace UtilsLocal
{
	public class Email
	{
		private static readonly bool SendEmails = bool.Parse(ConfigurationManager.AppSettings["SendEmails"]);
		private static readonly bool SendEmailsToRecipient = bool.Parse(ConfigurationManager.AppSettings["SendEmailsToRecipient"]);

		private readonly MailAddress _from;
		private const string FromPassword = "asdqwe123booktera";
		private const string FromEmail = "booktera1@gmail.com";
		private const string FromName = "BookTera";

		private readonly MailAddress _to;
		private readonly string _subject;
		private readonly string _body;

		public Email(string toEmail, string toName, string subject, string body)
		{
			_from = new MailAddress(FromEmail, FromName);
			_subject = subject;
			_body = body;
			_to = SendEmailsToRecipient
				? new MailAddress(toEmail, toName)
				: _from;
		}

		public Email(string subject, string body)
			: this(FromEmail, FromName, subject, body)
		{
		}

		/// <summary>
		/// Asynchronously sends an e-mail. Better said, sends an e-mail in a new thread
		/// </summary>
		/// <param name="force"></param>
		public void SendAsync(bool force = false)
		{
			new TaskFactory().StartNew(() => Send(force));
		}

		public void Send(bool force = false)
		{
			if(!SendEmails && !force)
				return;

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(_from.Address, FromPassword)
			};
			using(var message = new MailMessage(_from, _to) { Subject = _subject, Body = _body })
			{
				try
				{
					smtp.Send(message);
				}
				catch(Exception e)
				{
					const string msg = "Nem sikerült elküldeni az EMailt. ";
					throw new BookteraException(msg, e, BookteraExceptionCode.SendEmail);
				}
			}
		}

		#region BookTera Send Emails

		public static void SendEmailByOrderSending(string vendorEmail, string vendorName)
		{
			// Send email to vendor
			try
			{
				const string subject = "BookTera - Rendelésed érkezett";
				var body = new StringBuilder();
				body.AppendGreetingLines(vendorName);
				body.AppendLine("Vásároltak Tőled a BookTera oldalon.");
				body.AppendVendorsFindDetailsLine();
				body.AppendGoodByLines();

				var email = new Email(vendorEmail, vendorName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt
		}
		public static void SendEmailByExchangeOffering(string customerEmail, string customerName)
		{
			// Send email to customer
			try
			{
				const string subject = "BookTera - Csere ajánlatod érkezett";
				var body = new StringBuilder();
				body.AppendGreetingLines(customerName);
				body.AppendLine("Korábbi vásárlásodra az eladó könyv csere ajánlatot tett.");
				body.AppendCustomersFindDetailsLine();
				body.AppendGoodByLines();

				var email = new Email(customerEmail, customerName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt
		}
		public static void SendEmailsByOrderFinalizingWithoutExchange(string customerEmail, string customerName, string vendorEmail, string vendorName)
		{
			// Send email to vendor
			try
			{
				const string subject = "BookTera - Véglegesítetted a vásárlást";
				var body = new StringBuilder();
				body.AppendGreetingLines(vendorName);
				body.AppendLine("Sikeresen véglegesítetted egy eladásod.");
				body.AppendVendorsFindDetailsLine();
				body.AppendFeeAndCloseLines();
				body.AppendGoodByWithCustomersDataLines(customerName, customerEmail);

				var email = new Email(vendorEmail, vendorName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

			// Send email to customer
			try
			{
				const string subject = "BookTera - Vásárlásod az eladó véglegesítette";
				var body = new StringBuilder();
				body.AppendGreetingLines(customerName);
				body.AppendLine("Korábbi vásárlásod az eladó véglegesítette; nem cserél könyvet veled, ki kell fizetned neki a rendelésed.");
				body.AppendCustomersFindDetailsLine();
				body.AppendFeeAndCloseLines();
				body.AppendGoodByWithVendorsDataLines(vendorName, vendorEmail);

				var email = new Email(customerEmail, customerName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt
		}
		public static void SendEmailsByOrderFinalizingWithAcceptedExchange(string customerEmail, string customerName, string vendorEmail, string vendorName)
		{
			// Send email to vendor
			try
			{
				const string subject = "BookTera - Csere ajánlatod elfogadták";
				var body = new StringBuilder();
				body.AppendGreetingLines(vendorName);
				body.AppendLine("Korábban vásároltak Tőled, Te pedig csere ajánlatot tettél a vásárlásra. A vevő elfogadta az ajánlatod; így köteles vagy fizetés nélkül könyve(ke)t cserélni vele.");
				body.AppendVendorsFindDetailsLine();
				body.AppendFeeAndCloseLines();
				body.AppendGoodByWithCustomersDataLines(customerName, customerEmail);

				var email = new Email(vendorEmail, vendorName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

			// Send email to customer
			try
			{
				const string subject = "BookTera - A csere ajánlatot elfogadtad";
				var body = new StringBuilder();
				body.AppendGreetingLines(customerName);
				body.AppendLine("Korábbi vásárlásodra az eladó csere ajánlatot tett, amit Te sikeresen elfogadtál; így az eladó köteles fizetés nélkül könyve(ke)t cserélni veled.");
				body.AppendCustomersFindDetailsLine();
				body.AppendFeeAndCloseLines();
				body.AppendGoodByWithVendorsDataLines(vendorName, vendorEmail);

				var email = new Email(customerEmail, customerName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt
		}
		public static void SendEmailsByOrderFinalizingWithDeniedExchange(string customerEmail, string customerName, string vendorEmail, string vendorName)
		{
			// Send email to vendor
			try
			{
				const string subject = "BookTera - Csere ajánlatod elutasították";
				var body = new StringBuilder();
				body.AppendGreetingLines(vendorName);
				body.AppendLine("Korábban vásároltak Tőled, Te pedig csere ajánlatot tettél a vásárlásra. A vevő elutasította az ajánlatod; így köteles kifizetni Neked a könyve(ke)t.");
				body.AppendVendorsFindDetailsLine();
				body.AppendFeeAndCloseLines();
				body.AppendGoodByWithCustomersDataLines(customerName, customerEmail);

				var email = new Email(vendorEmail, vendorName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

			// Send email to customer
			try
			{
				const string subject = "BookTera - A csere ajánlatot elutasítottad";
				var body = new StringBuilder();
				body.AppendGreetingLines(customerName);
				body.AppendLine("Korábbi vásárlásodra az eladó csere ajánlatot tett, amit Te sikeresen elutasítottál; így köteles vagy kifezetni az eladónak a könyve(ke)t.");
				body.AppendCustomersFindDetailsLine();
				body.AppendFeeAndCloseLines();
				body.AppendGoodByWithVendorsDataLines(vendorName, vendorEmail);

				var email = new Email(customerEmail, customerName, subject, body.ToString());
				email.SendAsync();
			}
			catch(Exception e)
			{
			} // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt
		}
		public static void SendEmailByCloseOrder(bool wasSuccessful, bool didCustomer, string customerEmail, string customerName, string vendorEmail, string vendorName)
		{
			const string subjectSuccessful = "BookTera - Visszajelzés tranzakcióról - Sikeresen lezajlott";
			const string subjectUnsuccessful = "BookTera - Visszajelzés tranzakcióról - Sikertelen";

			const string msgSuccessfulToVendorIfCustomer = "A vevő sikeresen lezajlottnak értékelte egyik tranzakciód.";
			const string msgSuccessfulToCusomerIfVendor = "Az eladó sikeresen lezajlottnak értékelte egyik tranzakciód.";
			const string msgSuccessfulToSelf = "Sikeresen lezajlottnak értékelted egyik tranzakciód.";

			const string msgUnsuccessfulToVendorIfCustomer = "A vevő sikertelennek értékelte egyik tranzakciód.";
			const string msgUnsuccessfulToCusomerIfVendor = "Az eladó sikertelennek értékelte egyik tranzakciód.";
			const string msgUnsuccessfulToSelf = "Sikertelennek értékelted egyik tranzakciód.";

			#region didCustomer && wasSuccessful

			if(didCustomer && wasSuccessful)
			{
				// Send email to vendor if transaction was successful, and customer gave the feedback
				try
				{
					const string subject = subjectSuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(vendorName);
					body.AppendLine(msgSuccessfulToVendorIfCustomer);
					body.AppendVendorsFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(vendorEmail, vendorName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

				// Send email to customer if transaction was successful, and customer gave the feedback
				try
				{
					const string subject = subjectSuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(customerName);
					body.AppendLine(msgSuccessfulToSelf);
					body.AppendCustomersFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(customerEmail, customerName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt}
			}

			#endregion

			#region didCustomer && !wasSuccessful

			if(didCustomer && !wasSuccessful)
			{
				// Send email to vendor if transaction was unsuccessful, and customer gave the feedback
				try
				{
					const string subject = subjectUnsuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(vendorName);
					body.AppendLine(msgUnsuccessfulToVendorIfCustomer);
					body.AppendVendorsFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(vendorEmail, vendorName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

				// Send email to customer if transaction was unsuccessful, and customer gave the feedback
				try
				{
					const string subject = subjectUnsuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(customerName);
					body.AppendLine(msgUnsuccessfulToSelf);
					body.AppendCustomersFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(customerEmail, customerName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt}
			}

			#endregion

			#region !didCustomer && !wasSuccessful

			if(!didCustomer && !wasSuccessful)
			{
				// Send email to vendor if transaction was unsuccessful, and vendor gave the feedback
				try
				{
					const string subject = subjectUnsuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(vendorName);
					body.AppendLine(msgUnsuccessfulToSelf);
					body.AppendVendorsFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(vendorEmail, vendorName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

				// Send email to customer if transaction was unsuccessful, and vendor gave the feedback
				try
				{
					const string subject = subjectUnsuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(customerName);
					body.AppendLine(msgUnsuccessfulToCusomerIfVendor);
					body.AppendCustomersFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(customerEmail, customerName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt}
			}

			#endregion

			#region !didCustomer && wasSuccessful

			if(!didCustomer && wasSuccessful)
			{
				// Send email to vendor if transaction was successful, and vendor gave the feedback
				try
				{
					const string subject = subjectSuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(vendorName);
					body.AppendLine(msgSuccessfulToSelf);
					body.AppendVendorsFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(vendorEmail, vendorName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt

				// Send email to customer if transaction was successful, and vendor gave the feedback
				try
				{
					const string subject = subjectSuccessful;
					var body = new StringBuilder();
					body.AppendGreetingLines(customerName);
					body.AppendLine(msgSuccessfulToCusomerIfVendor);
					body.AppendCustomersFindDetailsLine();
					body.AppendGoodByLines();

					var email = new Email(customerEmail, customerName, subject, body.ToString());
					email.SendAsync();
				}
				catch(Exception e) { } // Ha nem megy ki egy e-mail, az ne tartsa fel az oldalt}
			}

			#endregion
		}

		#endregion
	}

	static class LocalStringBuilderExtension
	{
		public static void AppendGreetingLines(this StringBuilder stringBuilder, string toName)
		{
			stringBuilder.AppendFormat("Kedves {0}!", toName);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
		}
		public static void AppendVendorsFindDetailsLine(this StringBuilder stringBuilder)
		{
			stringBuilder.Append("A részleteket bejelentkezés után a következő helyen láthatod: ");
			stringBuilder.AppendLine("Főmenü -> Eladás -> Tranzakcióim -> Folyamatban. ");
		}
		public static void AppendCustomersFindDetailsLine(this StringBuilder stringBuilder)
		{
			stringBuilder.Append("A részleteket bejelentkezés után a következő helyen láthatod: ");
			stringBuilder.AppendLine("Főmenü -> Vásárlás -> Megrendeltek. ");
		}
		public static void AppendFeeAndCloseLines(this StringBuilder stringBuilder)
		{
			stringBuilder.AppendLine("Itt találod továbbá a BookTera felé fizetendő jutalékod összegét; illetve itt tudod a könyv vásárlás megtörténte után sikeresnek/sikertelennek lezárni a tranzakciót. ");
			stringBuilder.AppendLine();
		}
		public static void AppendGoodByWithVendorsDataLines(this StringBuilder stringBuilder, string vendorName, string vendorEmail)
		{
			stringBuilder.AppendLine("Az eladó adatai:");
			stringBuilder.AppendGoodByWithDataLines(vendorName, vendorEmail);
		}
		public static void AppendGoodByWithCustomersDataLines(this StringBuilder stringBuilder, string customerName, string customerEmail)
		{
			stringBuilder.AppendLine("A vevő adatai:");
			stringBuilder.AppendGoodByWithDataLines(customerName, customerEmail);
		}
		public static void AppendGoodByWithDataLines(this StringBuilder stringBuilder, string othersName, string othersEmail)
		{
			stringBuilder.Append("Név: ").AppendLine(othersName);
			stringBuilder.Append("E-mail cím: ").AppendLine(othersEmail);
			stringBuilder.AppendGoodByLines();
		}
		public static void AppendGoodByLines(this StringBuilder stringBuilder)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Üdv.: BookTera");
		}
	}
}
