using ETicaretAPI.Application.Validations.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices();
//builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
//builder.Services.AddCors(options => options.AddPolicy("ETicaretClient", policy => policy.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddCors(options => options.AddDefaultPolicy(options => options.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
//app.UseCors("ETicaretClient");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
