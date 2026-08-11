using MembershipManagement.API.Hubs;
using MembershipManagement.Application;
using MembershipManagement.Application.Notifications.Services;
using MembershipManagement.Infrastructure;
using MembershipManagement.Infrastructure.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddSignalR();
builder.Services.AddInfrastructure(
    builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<
    INotificationService,
    SignalRNotificationService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("SignalRTest", policy =>
    {
        policy
            .WithOrigins("http://localhost:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
var app = builder.Build();
app.UseCors("SignalRTest");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("SignalRTest");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.MapHub<NotificationHub>("/hubs/notifications");
app.Run();