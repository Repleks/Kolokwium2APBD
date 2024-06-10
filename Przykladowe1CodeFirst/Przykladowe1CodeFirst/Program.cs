using Microsoft.EntityFrameworkCore;
using Przykladowe1CodeFirst.Context;
using Przykladowe1CodeFirst.Endpoints;
using Przykladowe1CodeFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
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

baseEndpointsGroup.RegisterGroupsEndpoints();
baseEndpointsGroup.RegisterStudentsEndpoint();

app.Run();