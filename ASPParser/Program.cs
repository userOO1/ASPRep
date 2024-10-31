using Parser.Core.ss;
using Parser.Core;
using System.Reflection.PortableExecutable;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.UseDeveloperExceptionPage();

app.UseRouting();


app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table>");
    Parse<string[]> parser;


    parser = new Parse<string[]>(
                        new HabraParser()
                    );


    var parse = await parser.Worker();
    int count = 0;

    for (int page = 0; page < parse.Count; page++)
    {
        stringBuilder.Append("<tr>");
        foreach (var s in parse[page])
        {
            count++;
            stringBuilder.Append($"<td>{s}</td>");
            if (count%4==0 & parse[page].Length!=count)
            {
                stringBuilder.Append("</tr><tr>");
            }
            
            
        }
        stringBuilder.Append("</tr>");

    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
});

app.Run();