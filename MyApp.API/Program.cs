using FluentValidation;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Users.Commands;
using MyApp.Application.Mappings;
using MyApp.Domain.UnitOfWork;
using MyApp.Infrastructure.UnitOfWork;
using MyApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// کانفیگ EF Core SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ثبت UnitOfWork و Repository EF Core
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();

// ثبت Validatorها
builder.Services.AddValidatorsFromAssemblyContaining<AddUserCommandValidator>();

// ثبت AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ثبت MediatR
builder.Services.AddMediatR(typeof(AddUserCommand).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
