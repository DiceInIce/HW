
using System.Text;
using SomeApp.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

List<TaskResponseDto> tasks = new()
{
  new()
  {
    Id = Guid.NewGuid(),
    Name = "Buy milk",
  },
  new()
  {
    Id = Guid.NewGuid(),
    Name = "Drink milk",
  },
}; // База данных

object obj = new object();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");  // Проверять не нужно

app.MapGet("/table", async (ctx) =>    // Проверять не нужно
{
    var html = new StringBuilder("<table border='1'>");
    for (int i = 1; i <= 10; i++)
    {
        html.Append("<tr>");
        for (int j = 1; j <= 10; j++)
        {
            html.Append($"<td>{i * j}</td>");
        }
    }
    html.Append("</table>");

    ctx.Response.StatusCode = 200;

    ctx.Response.ContentType = "text/html utf-8";

    await ctx.Response.WriteAsync(html.ToString());
});

app.MapGet("/tasks", async (ctx) =>
{
    await ctx.Response.WriteAsJsonAsync(tasks);
});

app.MapPost("/tasks", async (HttpContext ctx, [FromBody] TaskRequestDto dto) => // Скриншот из Postman
{
    TaskResponseDto resp = new()
    {
        Id = Guid.NewGuid(),
        Name = dto.Name
    };

    lock (obj)
    {
        tasks.Add(resp);
    }

    await ctx.Response.WriteAsJsonAsync(resp);
}
);

app.MapDelete("/tasks/{Id}", async (HttpContext ctx, string Id) => // Скриншот из Postman
{
    try
    {
        var task = tasks.FirstOrDefault<TaskResponseDto>((t) => t.Id.ToString().Equals(Id));
        if (task == null)
        {
            ctx.Response.StatusCode = 404;
            await ctx.Response.WriteAsJsonAsync(new { Message = $"Задачи c ID {Id} не найдена!" });

        }
        tasks.Remove(task);
        ctx.Response.StatusCode = 200;

        await ctx.Response.WriteAsJsonAsync(new { Message = $"Задача ID {Id} успешно удалена!" });
    }
    catch
    {
        ctx.Response.StatusCode = 404;
        await ctx.Response.WriteAsJsonAsync(new List<TaskResponseDto>().ToString());
    }
});

app.MapPut("/tasks/{id}", async (HttpContext ctx, string id, [FromBody] TaskRequestDto dto) =>
{
    var task = tasks.FirstOrDefault(t => t.Id.ToString().Equals(id));
    if (task == null)
    {
        ctx.Response.StatusCode = 404;
        await ctx.Response.WriteAsJsonAsync(new { Message = $"Задача с ID {id} не найдена!" });
        return;
    }

    task.Name = dto.Name;
    ctx.Response.StatusCode = 200;
    await ctx.Response.WriteAsJsonAsync(task);
});

app.MapGet("/search", async (HttpContext ctx, string query) =>
{
    var results = tasks.Where(t => t.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    await ctx.Response.WriteAsJsonAsync(results);
});