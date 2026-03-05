var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/add", (AddRequest? request) =>
{
    if (request is null || !request.A.HasValue || !request.B.HasValue)
    {
        return Results.BadRequest(new { error = "Invalid input. Both 'a' and 'b' are required." });
    }

    var result = request.A.Value + request.B.Value;
    return Results.Ok(new { result });
});

app.Run();

record AddRequest(double? A, double? B);
