using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace RaizesNordeste.Api.OpenApi;

public sealed class BearerSecurityRequirementTransformer
    : IOpenApiOperationTransformer
{
    public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken cancellationToken)
    {
        var metadata = context.Description.ActionDescriptor.EndpointMetadata;

        var permiteAnonimo = metadata.OfType<IAllowAnonymous>().Any();

        var exigeAutenticacao = metadata.OfType<IAuthorizeData>().Any();

        if (!permiteAnonimo && exigeAutenticacao)
        {
            operation.Security ??= [];

            operation.Security.Add(new OpenApiSecurityRequirement{[new OpenApiSecuritySchemeReference("Bearer",context.Document)] = []});
        }

        return Task.CompletedTask;
    }
}