using Fiap.Emailify.Data.Contexts;
using Fiap.Emailify.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Fiap.Emailify.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {

            if (context.Emails.Count() == 0)
            {
                // Adiciona dados de exemplo para Emails
                var emails = new List<Email>
                {
                    new Email
                    {
                        Sender = "user1@example.com",
                        Recipients = ["user2@example.com", "user3@example.com"],
                        Subject = "Meeting Reminder",
                        Body = "Don't forget about the meeting tomorrow.",
                        SentDate = DateTime.Now.AddMinutes(-10)
                    },
                    new Email
                    {
                        Sender = "user2@example.com",
                        Recipients = ["user1@example.com", "user3@example.com"],
                        Subject = "Re: Meeting Reminder",
                        Body = "Got it, see you tomorrow.",
                        SentDate = DateTime.Now.AddMinutes(-5)
                    }
                };

                context.Emails.AddRange(emails);
            }

            if(context.CalendarEvents.Count() == 0)
            {
                // Adiciona dados de exemplo para CalendarEvents
                var calendarEvents = new List<CalendarEvent>
                {
                    new CalendarEvent
                    {
                        Title = "Team Meeting",
                        Description = "Discuss project updates.",
                        StartDate = DateTime.Now.AddHours(1),
                        EndDate = DateTime.Now.AddHours(2),
                        Location = "Conference Room"
                    },
                    new CalendarEvent
                    {
                        Title = "Doctor Appointment",
                        Description = "Annual health check-up.",
                        StartDate = DateTime.Now.AddDays(1).AddHours(9),
                        EndDate = DateTime.Now.AddDays(1).AddHours(10),
                        Location = "Health Clinic"
                    }
                };
                context.CalendarEvents.AddRange(calendarEvents);
            }
            // Salva as alterações no banco de dados
            context.SaveChanges();
        }
    }
}
