using Microsoft.Extensions.Options;
using MyApiProject.Models.Sys;

var builder = WebApplication.CreateBuilder(args);

var allowSpecificOrigins = "AllowOrigins";
var allowedOrigins = builder.Configuration.GetSection("System:WithOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowSpecificOrigins, policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.Configure<SystemSettings>(builder.Configuration.GetSection("System"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

