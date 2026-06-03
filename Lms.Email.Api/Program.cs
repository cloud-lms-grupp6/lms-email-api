using Lms.Email.Api.Services;
using Lms.Email.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Email Service
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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