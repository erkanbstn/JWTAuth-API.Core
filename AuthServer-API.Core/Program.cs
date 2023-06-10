using AuthServer_API.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();
var app = builder.Build();
app.ConfigureApp();

