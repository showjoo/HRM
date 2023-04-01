
using System.Text;
using Interviews.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionString");
// Inject our ConnectionString into DbContext
//builder.Services.AddDbContext<RecruitingDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection"))
//);
//builder.Services.AddDbContext<RecruitingDbContext>(options => options.UseSqlServer(dockerConnectionString));
builder.Services.AddDbContext<InterviewsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewsDbConnection")));

// Microsoft.AspNetCore.Authentication.JwtBearer
// Microsoft.IdentityModel.Tokens
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme  )
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "HRM",
            ValidAudience = "HRM Users",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
        };
    } );


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();