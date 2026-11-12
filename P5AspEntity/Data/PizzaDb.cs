using Microsoft.EntityFrameworkCore;
using P5AspEntity.Models;

namespace P5AspEntity.Data;

/// <summary>Contexte EF Core : coordonne l'accès à la base de données.</summary>
public class PizzaDb(DbContextOptions<PizzaDb> options) : DbContext(options)
{
    public DbSet<Pizza> Pizzas => Set<Pizza>();
}
