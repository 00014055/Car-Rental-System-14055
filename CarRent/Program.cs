using CarRent.Data;
using Microsoft.EntityFrameworkCore;
using CarRent.Controllers;
using CarRent.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>

{

  options.AddPolicy(MyAllowSpecificOrigins,

             policy =>

             {

               policy.WithOrigins("http://localhost:4200")

                         .AllowAnyHeader()

                         .AllowAnyMethod()

                         .AllowAnyOrigin();

             });

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarRentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
