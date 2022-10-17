using HorrorBank.Business.Business;
using HorrorBankDAL.Configuration;
using HorrorBankDAL.DbManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbManager, DbManager>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IAuthBusiness, AuthBusiness>();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.json", false);
}

builder.Services.Configure<Configuration>(builder.Configuration.GetSection("Configuration"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
