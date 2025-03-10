using NLog.Web;
using NLog;
using NLog.Config;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using BusinessLayer.Service;
using RepositoryLayer.Service;
using Microsoft.AspNetCore.Http;
using MiddleWare.GlobalExceptionHandling;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");//used for connection to database
builder.Services.AddDbContext<GreetingContext>(options => options.UseSqlServer(connectionString));
var ConnectionString = builder.Configuration.GetConnectionString("SqlConnection");//used for loggin user connection to database
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(ConnectionString));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Services.AddScoped<IGreetingRL, GreetingRL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserRL, UserRL>();

//logger using NLog
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
LogManager.Configuration = new XmlLoggingConfiguration("D:\\NEW HelloApp gitrepo\\nlog.config");

logger.Debug("init main");

builder.Logging.ClearProviders();
builder.Host.UseNLog();
var app = builder.Build();

//logger dependency injection

//Add swagger to container

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<MiddleWare.GlobalExceptionHandling.GlobalExceptionHandler>();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();