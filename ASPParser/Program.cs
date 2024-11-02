using Parser.Core.ss;
using Parser.Core;
using System.Reflection.PortableExecutable;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
Parse<List<Order>> parser;


parser = new Parse<List<Order>>(
                    new HabraParser()
                );


List<List<Order>> parse = await parser.Worker();
app.MapGet("/api/parse", () => parse);
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");
//    Parse<List<Order>> parser;
//
//
//    parser = new Parse <List <Order>>(
//                        new HabraParser()
//                    );
//
//
//    List<List<Order>> parse = await parser.Worker();
//    int count = 5;
//    
//    for (int page = 0; page < count; page++)
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            
//            stringBuilder.Append("<tr>");
//            
//            stringBuilder.Append($"<td>{parse[page][i].ItemsNumber}</td>");
//            stringBuilder.Append($"<td>{parse[page][i].ItemsObject}</td>");
//            stringBuilder.Append($"<td>{parse[page][i].ItemsPrice}</td>");
//            stringBuilder.Append($"<td>{parse[page][i].ItemsFz}</td>");
//            stringBuilder.Append($"<td>{parse[page][i].ItemsCustomer}</td>");
//            //if (count%4==0 & parse[page].Length!=count)
//            //{
//            //    stringBuilder.Append("</tr><tr>");
//            //}
//            stringBuilder.Append("</tr>");
//
//
//        }
//        
//
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

app.Run();