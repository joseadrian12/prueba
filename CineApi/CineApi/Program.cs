using CineApi.Data;
using CineApi.Repository;
using CineApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<CineContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CineConnection")
    )
);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PeliculaRepository>();
builder.Services.AddScoped<PeliculaService>();

builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<SalaRepository>();

builder.Services.AddScoped<AsignacionRepository>();
builder.Services.AddScoped<AsignacionService>();

builder.Services.AddScoped<DashboardRepository>();
builder.Services.AddScoped<DashboardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowAngular");

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
