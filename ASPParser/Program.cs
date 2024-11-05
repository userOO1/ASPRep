using Parser.Core.ss;
using Parser.Core;
using System.Reflection.PortableExecutable;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
Parsing<List<Order>> parser;


parser = new Parsing<List<Order>>(
                    new EisParser()
                );


List<List<Order>> parse = await parser.Worker();
app.MapGet("/api/parse", () => parse);


app.Run();