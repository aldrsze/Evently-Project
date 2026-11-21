using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Evently.Core.Helpers;

namespace Evently.Core.Services
{
    public static class EmailService
    {
        // Sends ticket email with attached QR code via Gmail SMTP
        public static bool SendTicketEmail(string recipientEmail, string attendeeName, string eventName, string venue, DateTime eventDate, string ticketId)
        {
            string configPath = Path.Combine(AppContext.BaseDirectory, "db.config");
            if (!File.Exists(configPath))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(configPath);
            string smtpEmail = DatabaseConnection.ReadValue(lines, "SmtpEmail");
            string smtpPassword = DatabaseConnection.ReadValue(lines, "SmtpPassword");

            if (smtpEmail.Length == 0 || smtpPassword.Length == 0)
            {
                return false;
            }

            try
            {
                byte[] qrBytes = QrCodeService.GenerateTicketQrPng(ticketId);

                using MailMessage mail = new();
                mail.From = new MailAddress(smtpEmail, "Evently");
                mail.To.Add(recipientEmail);
                mail.Subject = $"Your Ticket for {eventName}";
                mail.Body = $"Hi {attendeeName},\n\nHere is your ticket for {eventName}.\nVenue: {venue}\nDate: {eventDate:MMMM d, yyyy h:mm tt}\nTicket ID: {ticketId}\n\nPlease present the attached QR code at the door.";

                using MemoryStream stream = new(qrBytes);
                mail.Attachments.Add(new Attachment(stream, "ticket_qr.png", "image/png"));

                using SmtpClient client = new("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpEmail, smtpPassword);
                client.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
