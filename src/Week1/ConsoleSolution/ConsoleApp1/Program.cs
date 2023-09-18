var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/message", () =>
{
    var response = new MessageResponseModel("This is an API! Wow!", DateTime.Now);
    return Results.Ok(response);
});


app.Run();


public record MessageResponseModel(string Message, DateTime When);
