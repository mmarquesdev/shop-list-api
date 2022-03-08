using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopList.Domain.Repositories;
using ShopList.Infra.Context;
using ShopList.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors-shoplist", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ShopListDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseAdmin")));

builder.Services.AddScoped<IBoardItemRepository, BoardItemRepository>();
builder.Services.AddScoped<IBoardRepository, BoardRepository>();

var projetcId = "shop-list-proj"; 
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://securetoken.google.com/{projetcId}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/{projetcId}",
            ValidateAudience = true,
            ValidAudience = $"{projetcId}",
            ValidateLifetime = true
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mediatr
builder.Services.AddMediatR(
    AppDomain.CurrentDomain.Load("ShopList.Api"),
    AppDomain.CurrentDomain.Load("ShopList.Domain"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("cors-shoplist");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
