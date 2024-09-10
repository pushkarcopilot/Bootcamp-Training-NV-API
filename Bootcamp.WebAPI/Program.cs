using Bootcamp.Data.Context;
using Bootcamp.Data.Interface;
using Bootcamp.Data.Implementation;
using Microsoft.AspNetCore.Components.Forms;
using Bootcamp.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Auditcontext>();
builder.Services.AddScoped<IClientDetailsService, ClientDetailsService>();
builder.Services.AddScoped<IAuthUser, AuthUser>();
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddControllers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
