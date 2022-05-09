var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var startup = new Startup(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);
startup.Configure(app, app.Environment);