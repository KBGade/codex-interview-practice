using InterviewPracticeApi.Models;
using InterviewPracticeApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Ok(new
{
    message = "Interview Practice API is running"
}));

app.MapGet("/orders", (OrderService orderService) =>
{
    var orders = orderService.GetAll();
    return Results.Ok(orders);
});

app.MapGet("/orders/{id:int}", (int id, OrderService orderService) =>
{
    var order = orderService.GetById(id);

    return order is null
        ? Results.NotFound(new { message = $"Order with id {id} was not found." })
        : Results.Ok(order);
});

app.MapPost("/orders", (Order order, OrderService orderService) =>
{
    try
    {
        var created = orderService.Create(order);
        return Results.Created($"/orders/{created.Id}", created);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.MapDelete("/orders/{id:int}", (int id, OrderService orderService) =>
{
    var deleted = orderService.Delete(id);

    return deleted
        ? Results.NoContent()
        : Results.NotFound(new { message = $"Order with id {id} was not found." });
});

app.Run();