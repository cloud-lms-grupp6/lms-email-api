namespace Lms.Email.Api.Services;

// EmailService ansvarar för att hantera utskick av e-post.
// I den här versionen används en mockad implementation som skriver ut
// e-postmeddelandet i konsolen istället för att skicka det på riktigt.
//
// AI användes som stöd för att strukturera service-lagret.
// Implementationen anpassades därefter manuellt för projektets Proof of Concept.

public class EmailService : IEmailService
{
    // Tar emot mottagare, ämne och meddelande.
    // För närvarande loggas informationen till konsolen för testning.
    public Task SendEmailAsync(string to, string subject, string body)
    {
        Console.WriteLine("===== EMAIL =====");

        // Visar mottagarens e-postadress.
        Console.WriteLine($"To: {to}");

        // Visar e-postens ämnesrad.
        Console.WriteLine($"Subject: {subject}");

        // Visar innehållet i e-postmeddelandet.
        Console.WriteLine($"Body: {body}");

        Console.WriteLine("=================");

        return Task.CompletedTask;
    }
}