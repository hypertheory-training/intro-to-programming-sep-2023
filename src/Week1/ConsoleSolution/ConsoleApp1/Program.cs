var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/message", () =>
{
    var response = new MessageResponseModel("This is an API! Wow!", DateTime.Now);
    return Results.Ok(response);
});

app.MapGet("/states", () =>
{
    var states = new Dictionary<string, string>
    {
        { "OH", "Ohio" },
        { "KY", "Kentucy" },
        { "CO", "Colorado" },
        { "PR", "Puerto Rico" }
    };
    return Results.Ok(states);
});

app.MapGet("/policies/{policyNumber}", (string policyNumber) =>
{
    return Results.Ok(new { policyNumber });
});

app.Run();


public record MessageResponseModel(string Message, DateTime When);
