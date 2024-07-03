using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configure the HTTP request pipeline to use HTTPS redirection
app.UseHttpsRedirection();

// Summary: Implements an API to calculate the probability of getting a specified number of heads in coin tosses.
// Endpoint '/api/J3/CoinTossProbability/{n}/{heads}' accepts parameters: {n} (1 ≤ n ≤ 100) for total tosses and {heads} (0 ≤ {heads} ≤ n) for heads.
// Calculates using binomial probability and returns formatted response indicating probability of {heads} heads in {n} tosses.
// Example Usage: GET /api/J3/CoinTossProbability/3/2 -> "The probability of getting 2 heads in 3 coin tosses is 0.375."
//                GET /api/J3/CoinTossProbability/4/1 -> "The probability of getting 1 heads in 4 coin tosses is 0.25."
app.MapGet("/api/J3/CoinTossProbability/{n:int}/{heads:int}", (int n, int heads) =>
{
    if (heads < 0 || heads > n)
    {
        return Results.BadRequest("Invalid number of heads.");
    }

    double probability = CalculateBinomialProbability(n, heads);
    return Results.Ok($"The probability of getting {heads} heads in {n} coin tosses is {probability:F6}.");
});

// Summary: Calculates the binomial probability of getting exactly k heads in n coin tosses.
// Parameters: n - The number of coin tosses, k - The number of heads
// Returns: The binomial probability
double CalculateBinomialProbability(int n, int k)
{
    return BinomialCoefficient(n, k) * Math.Pow(0.5, n);
}

// Summary: Calculates the binomial coefficient "n choose k".
// Parameters: n - The number of items, k - The number of choices
// Returns: The binomial coefficient
double BinomialCoefficient(int n, int k)
{
    if (k > n - k)
    {
        k = n - k;
    }

    double result = 1;
    for (int i = 0; i < k; i++)
    {
        result *= (n - i);
        result /= (i + 1);
    }

    return result;
}

app.Run();
