using ASPParser.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Parser.Core.ss;
using Parser.Core;

var builder = WebApplication.CreateBuilder(args);

// Добавляем необходимые сервисы
// Регистрация зависимостей
builder.Services.AddScoped<IParser<List<Order>>, EisParser>();
builder.Services.AddScoped<IPageDataParser<List<Order>>, PageDataParser<List<Order>>>(); // Регистрация обертки для парсинга

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

