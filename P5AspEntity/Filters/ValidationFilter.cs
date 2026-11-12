using System.ComponentModel.DataAnnotations;

namespace P5AspEntity.Filters;

/// <summary>
/// Filtre d'endpoint : valide l'argument de type <typeparamref name="T"/> avec les
/// DataAnnotations et renvoie un 400 (ProblemDetails) en cas d'erreur.
/// </summary>
public sealed class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var model = context.Arguments.OfType<T>().FirstOrDefault();
        if (model is null)
        {
            return TypedResults.ValidationProblem(new Dictionary<string, string[]>
            {
                [typeof(T).Name] = ["Le corps de la requête est manquant."]
            });
        }

        var results = new List<ValidationResult>();
        if (Validator.TryValidateObject(model, new ValidationContext(model), results, validateAllProperties: true))
            return await next(context);

        var errors = results
            .SelectMany(r => (r.MemberNames.Any() ? r.MemberNames : [string.Empty])
                .Select(member => (Member: member, Message: r.ErrorMessage ?? "Valeur invalide.")))
            .GroupBy(x => x.Member)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());

        return TypedResults.ValidationProblem(errors);
    }
}
