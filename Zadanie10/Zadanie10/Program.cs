using Microsoft.EntityFrameworkCore;
using Zadanie10.Context;
using Zadanie10.Endpoints;
using Zadanie10.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var baseEndpointsGroup = app.MapGroup("api");

baseEndpointsGroup.RegisterAccountEndpoints();
baseEndpointsGroup.RegisterProductEndpoints();

app.Run();

