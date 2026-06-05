using Lms.Email.Api.Services;
using Lms.Email.Api.Models;

// Program.cs startar och konfigurerar Email API.
// Här registreras EmailService, API-endpoints och Swagger.
//
// AI användes som stöd för att förstå Minimal API-strukturen
// och dependency injection. Lösningen anpassades därefter
// manuellt efter LMS-projektets krav.

var builder = WebApplication.CreateBuilder(args);

// Aktiverar OpenAPI/Swagger för testning av API:t.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrerar EmailService i dependency injection.
// Detta gör att endpointen kan använda IEmailService.
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Aktiverar Swagger endast i utvecklingsmiljö.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint för att skicka e-post.
// Frontend eller andra tjänster skickar in mottagare,
// ämne och meddelande via SendEmailRequest.
app.MapPost("/api/email/send",
    async (SendEmailRequest request, IEmailService emailService) =>
{
    await emailService.SendEmailAsync(
        request.To,
        request.Subject,
        request.Body);

    return Results.Ok(new
    {
        message = "Email sent successfully"
    });
})
.WithName("SendEmail");

app.Run();