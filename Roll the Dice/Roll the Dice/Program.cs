using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configure the HTTP request pipeline to use HTTPS redirection
app.UseHttpsRedirection();

/// <summary>
/// Endpoint for solving the J2 problem - Roll the Dice
/// </summary>
/// <param name="m">Number of sides on the first die</param>
/// <param name="n">Number of sides on the second die</param>
/// <returns>Number of ways to get the sum of 10</returns>
/// <example>
/// GET /api/J2/DiceGame/6/8 -> "There are 5 total ways to get the sum 10."
/// GET /api/J2/DiceGame/12/4 -> "There are 4 total ways to get the sum 10."
/// GET /api/J2/DiceGame/3/3 -> "There are 0 total ways to get the sum 10."
/// GET /api/J2/DiceGame/5/5 -> "There is 1 total way to get the sum 10."
/// </example>
app.MapGet("/api/J2/DiceGame/{m:int}/{n:int}", (int m, int n) =>
{
    // Validate input to ensure dice sides are positive integers
    if (m <= 0 || n <= 0)
    {
        return Results.BadRequest("Invalid input. Please ensure the number of sides for both dice are positive integers.");
    }

    int count = 0;

    // Iterate over all possible combinations of dice rolls
    for (int i = 1; i <= m; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (i + j == 10)
            {
                count++;
            }
        }
    }

    // Formulate the result message
    string result = count == 1 ? $"There is {count} total way to get the sum 10." : $"There are {count} total ways to get the sum 10.";
    return Results.Ok(result);
});

app.Run();
