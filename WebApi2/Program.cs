using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.AddSingleton<ITokenHelper, JwtHelper>();
//builder.Services.AddSingleton<SecurityKeyHelper>();
//builder.Services.AddSingleton<TokenOptions>(builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>());
//builder.Services.AddSingleton<SigningCredentialsHelper>();


//IAuthService
builder.Services.AddSingleton<IAuthService, AuthManager>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();
builder.Services.AddSingleton<IUserDal, EfUsersDal>();





IHostBuilder hostBuilder = builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
    options.RegisterModule(new AutofacBusinessModule())
));


//IHostBuilder hostBuilder = builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
//    options.RegisterModule(new AutofacBusinessModule())
//));


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddSingleton(tokenOptions);
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
ServiceTool.Create(builder.Services);







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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

