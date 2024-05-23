//using JobPortalAPI.Data;
//using Microsoft.EntityFrameworkCore;
//using JobPortalAPI.Repository;
//using JobPortalAPI.Repository.Interfaces;
//using JobPortalAPI.Service.Interfaces;
//using JobPortalAPI.Service;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using JobPortalAPI.Models;
//using Microsoft.AspNetCore.Identity;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//var configuration = builder.Configuration;

//// Configure JWT settings
//var jwtIssuer = configuration["Jwt:Issuer"];
//var jwtKey = configuration["Jwt:Key"];

//builder.Services.AddDbContext<JobPortalDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<JobPortalDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtIssuer,
//        ValidAudience = jwtIssuer,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
//    };
//});

//builder.Services.AddControllers();

//builder.Services.AddDbContext<JobPortalDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddCors(options => { options.AddPolicy(name: "AllowAngularOrigin", builder => { builder.WithOrigins("http://localhost:4200"); }); });

//builder.Services.AddScoped<IUnitOfWorkRepository,UnitOfWorkRepository>();
//builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();



//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();    
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.UseAuthentication();
//app.UseCors("AllowAngularOrigin");
////app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//app.MapControllers();
//app.Run();
using JobPortalAPI.Data;
using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Repository;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Service.Interfaces;
using JobPortalAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using JobPortalAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Configure JWT settings
var jwtIssuer = configuration["Jwt:Issuer"];
var jwtKey = configuration["Jwt:Key"];

builder.Services.AddDbContext<JobPortalDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<JobPortalDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowBlazorOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials(); // Add this if you are using authentication and need credentials
        });
});

builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

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
app.UseCors("AllowBlazorOrigin"); // Apply CORS policy here
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
