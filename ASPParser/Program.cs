using ASPParser.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Parser.Core.ss;
using Parser.Core;

var builder = WebApplication.CreateBuilder(args);

// Добавляем необходимые сервисы


// Регистрация зависимостей

//builder.Services.AddScoped<IParsing<List<Order>>, Parsing<List<Order>>>(); // Регистрация Parsing

builder.Services.AddControllers(); // Регистрация контроллеров

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

// Добавляем маршрутизацию для контроллеров
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

