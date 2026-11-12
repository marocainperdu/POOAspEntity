using P5AspEntity.Data;
using P5AspEntity.Endpoints;
using P5AspEntity.Extensions;

// Point d'entrée : uniquement de la composition, aucune logique métier ici.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPizzaStore(builder.Configuration);

var app = builder.Build();

await app.InitialiseDatabaseAsync();
app.UsePizzaStore();
app.MapPizzaEndpoints();

app.Run();
