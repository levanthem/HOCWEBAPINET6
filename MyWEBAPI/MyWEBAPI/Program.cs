using Microsoft.EntityFrameworkCore;
using MyWEBAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Cau hinh ket noi database

var ConnectionStrings = builder.Configuration.GetConnectionString("MyDB");
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer(ConnectionStrings));

//IServiceCollection serviceCollection = builder.Services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase("MyDB"));


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
