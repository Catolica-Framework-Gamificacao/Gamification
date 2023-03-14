
using System.Text;
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
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Auth",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
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
app.MapControllers();
using (var context = new GamificationContext())
{
    context.Database.GetService<IMigrator>().Migrate();
    
}
Console.WriteLine("Starting Gamification API");
app.Run();
static void ConfigureServiceInjection(IServiceCollection services)
{
    services.AddTransient<IAuthService, AuthService>();
    services.AddTransient<IGamificationContext, GamificationContext>();
    services.AddTransient<IStudentService, StudentService>();
    services.AddTransient<ITeacherService, TeacherService>();
}