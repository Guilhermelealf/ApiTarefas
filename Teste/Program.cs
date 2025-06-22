using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Teste.Models;
using Microsoft.OpenApi.Models;
using Teste.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder
     .AddApiConfig()
     .AddSwaggerConfig()
     .AddDbContextConfig()
     .AddIdentityConfig();

var app = builder.Build();

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
