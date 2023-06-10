using AuthServer.Mini_API3.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();
var app = builder.Build();
app.ConfigureApp();
