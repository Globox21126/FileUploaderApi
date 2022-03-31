
using CanonImgApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//datacontext
builder.Services.AddDbContext<DataContext>(options =>
{
    //var server = configuration["DBServer"] ?? "localhost";
    //var port = configuration["DBPort"] ?? "1443";
    ////var user = configuration["DBUser"] ?? "SA";
    ////var password = configuration["DBPassword"] ?? "1";
    //var database = configuration["Database"] ?? "Imgs";

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.UseSqlServer($"Data Source={server}, {port};Initial Catalog={database};Integrated Security=false");

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
