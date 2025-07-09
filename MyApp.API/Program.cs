using FluentValidation;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyApp.Application.Users.Commands;
using MyApp.Application.Mappings;
using MyApp.Domain.UnitOfWork;
using MyApp.Infrastructure.UnitOfWork;
using MyApp.Infrastructure.Persistence;
using MyApp.Application.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// کانفیگ EF Core SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ثبت UnitOfWork و Repository EF Core
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();

// ثبت سرویس تولید JWT Token
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// تنظیمات JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

// ثبت Validatorها
builder.Services.AddValidatorsFromAssemblyContaining<AddUserCommandValidator>();

// ثبت AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

// ثبت MediatR
builder.Services.AddMediatR(typeof(AddUserCommand).Assembly);

builder.Services.AddControllers();

// تنظیم Swagger برای JWT Token Authorization
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApp API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // فعال کردن احراز هویت

app.UseAuthorization();

app.MapControllers();

app.Run();
