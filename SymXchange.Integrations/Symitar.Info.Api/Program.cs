using Microsoft.AspNetCore.Http.HttpResults;
using SymXchange.Service.Info;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration["SymXchangeConnectionString"];

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'SymXchangeConnectionString' is not configured.");
}

builder.Services.AddSymXchangeEpisysInformationService(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/info", async (EpisysInformationService service) =>
{
    var settings = service.SymXchangeSettings;

    var request = new getGeneralEpisysInformationRequest
    {
        Request = new GeneralEpisysInformationRequest
        {
            Credentials = new AdminCredentialsChoice
            {
                Item = new AdministrativeCredentials
                {
                    Password = settings.Password
                }
            },
            DeviceInformation = new DeviceInformation
            {
                DeviceNumber = settings.DeviceNumber,
                DeviceType = settings.DeviceType
            },
            MessageId = settings.MessageId
        },
    };

    var result = await service.getGeneralEpisysInformationAsync(request);
    return Results.Ok(result.Response);
})
.WithName("GetSymXchangeInfo");

app.Run();
