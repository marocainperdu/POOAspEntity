using System.ComponentModel.DataAnnotations;

namespace P5AspEntity.Models;

/// <summary>Entité Pizza persistée par Entity Framework Core.</summary>
public class Pizza
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La description ne doit pas dépasser 500 caractères.")]
    public string? Description { get; set; }
}
