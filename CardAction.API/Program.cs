using CardAction.API.DTOs;
using CardAction.Core.Extensions;
using CardAction.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CardService>();

builder.Services.AddCardActionCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapGet("/getactionforcard/{userId}/{cardNumber}", async (
    [FromServices] CardService cardService,
    [FromServices] ActionService actionService,
    string userId,
    string cardNumber) =>
{
    var card = await cardService.GetCardDetails(userId, cardNumber);

    if (card is null)
    {
        return Results.NotFound("User / Card not found");
    }

    var actions = actionService.GetAvailableActions(card);

    var returnCardDetail = new CardDTO
    (
        card.CardNumber,
        card.CardType,
        card.CardStatus,
        card.IsPinSet,
        actions
    );
   
    return Results.Ok(returnCardDetail);
})
.WithName("GetActionsForCard")
.WithOpenApi();

app.Run();
