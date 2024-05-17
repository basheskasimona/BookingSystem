using MockBookingSystem.Services.Managers;
using MockBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using MockBookingSystem.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddTransient<ISearchManagerFactory, SearchManagerFactory>();
builder.Services.AddTransient<ISearchManager, LastMinuteHotelsManager>();
builder.Services.AddTransient<ISearchManager, HotelAndFlightManager>();
builder.Services.AddTransient<ISearchManager, HotelOnlyManager>();

builder.Services.AddTransient<IManager, Manager>();
builder.Services.AddTransient<ICodeGenerator, CodeGenerator>();

builder.Services.AddHttpClient<ISearchClient, SearchClient>(client =>
{
    client.BaseAddress = new Uri("https://tripx-test-functions.azurewebsites.net/");
});
builder.Services.AddMemoryCache();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<XApiKeyAuthorizationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
