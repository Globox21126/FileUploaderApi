
using CanonImgApi.Data;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigin = "_myAllowSpecificOrigin";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//datacontext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowSpecificOrigin,
//        name =>
//        {
//            name.AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//        });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//enable all cors for test purposes
//app.UseCors(x => x
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    .AllowAnyHeader());

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
