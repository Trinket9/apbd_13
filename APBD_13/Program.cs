using APBD_13.Context;
using APBD_13.Endpoints;
using APBD_13.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

var endpoints = app.MapGroup("api");
endpoints.RegisterUserEndpoints();

app.UseHttpsRedirection();

app.Run();