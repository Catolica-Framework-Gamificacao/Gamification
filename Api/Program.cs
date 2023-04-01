
using System.Text;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Api.Services.Auth;
using Api.Services.Student;
using Api.Services.Teacher;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Database;
using Swashbuckle.AspNetCore.Filters;
var builder = WebApplication.CreateBuilder(args);
const string gamificationOrigins = "_gamificationOrigins";
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Auth",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfiguration.JwtKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: gamificationOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();
    });
});
ConfigureServiceInjection(builder.Services);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(gamificationOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
});
using (var context = new GamificationContext())
{
    context.Database.GetService<IMigrator>().Migrate();
    
}
Console.WriteLine("Starting Gamification API");
app.Run();
static void ConfigureServiceInjection(IServiceCollection services)
{
    #region DATABASE
    services.AddTransient<IGamificationContext, GamificationContext>();
    #endregion

    #region SERVICES
    services.AddTransient<IAuthService, AuthService>();
    services.AddTransient<IStudentService, StudentService>();
    services.AddTransient<ITeacherService, TeacherService>();
    #endregion

    #region REPOSITORIES

    services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
    services.AddTransient<IStudentRepository, StudentRepository>();
    services.AddTransient<ITeacherRepository, TeacherRepository>();
    #endregion
}