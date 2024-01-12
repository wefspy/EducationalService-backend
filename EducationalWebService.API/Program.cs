using EducationalWebService.Logic.Options;
using EducationalWebService.Logic.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Identity;
using EducationalWebService.Data.Models;
using EducationalWebService.Data.Context;
using EducationalWebService.API.Hubs;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Add Controllers.
builder.Services.AddControllers();

// Add SignalR
builder.Services.AddSignalR(options => 
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(60)); // Ñlose the inactive connection


// Add Context
builder.Services.AddDataBase(connectionString!);
builder.Services.AddSignalRBase();

// ConfigureIdentity for Logic Repositories
builder.Services
    .AddIdentity<User, Role>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;

        options.Lockout.MaxFailedAccessAttempts = 5;
    })
    .AddEntityFrameworkStores<EducationalWebServiceContext>()
    .AddDefaultTokenProviders();

// Add Logic
builder.Services.AddRepositories();
builder.Services.AddGenerators();

builder.Services.AddAuthentication(options =>
{
    // Add Bearer Generated-JWT-Token for Authentication
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["JwtBearer:Issuer"],

            ValidateAudience = true,
            ValidAudience = configuration["JwtBearer:Audience"],

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(configuration["JwtBearer:Secret"]!)), 
        };
    });

// Registers a configuration instance which JwtOption will bind against
builder.Services.Configure<JwtOptions>(configuration.GetSection("JwtBearer"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Education Web Service API", Version = "v1" });

    // Configuring Swagger to Send a JWT Token in a Request
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<SessionHub>("hubs/sessionHub");

app.Run();