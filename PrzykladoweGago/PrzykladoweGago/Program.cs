using Microsoft.EntityFrameworkCore;
using PrzykladoweGago.Contexts;
using PrzykladoweGago.Endpoints;
using PrzykladoweGago.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
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

baseEndpointsGroup.RegisterClientEndpoints();
baseEndpointsGroup.RegisterReservationEndpoints();

app.Run();

