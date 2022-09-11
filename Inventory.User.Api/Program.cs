using Inventory.Business.Core.Business;
using Inventory.Business.Core.Repositories.Product;
using Inventory.DataAccess.Repository;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Infrastructure.Models;
using Inventory.Domain.Infrastructure.Repositories.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserBusiness, UserBusiness>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddSingleton<IProductBusiness, ProductBusiness>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

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
